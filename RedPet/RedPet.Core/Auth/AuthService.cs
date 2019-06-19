using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RedPet.Common.Auth.Models;
using RedPet.Common.Extensions;
using RedPet.Common.Models.Auth;
using RedPet.Common.Models.Base;
using RedPet.Common.Models.User;
using RedPet.Database.Entities.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RedPet.Core.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IJwtFactory jwtFactory;
        private readonly JwtIssuerOptions jwtOptions;
        private readonly ICustomerService customerService;
        private readonly IUserService userService;
        private readonly IFacebookClient facebookClient;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public AuthService( IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions, 
            ICustomerService customerService, IUserService userService, IFacebookClient facebookClient, 
            SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.jwtFactory = jwtFactory;
            this.jwtOptions = jwtOptions.Value;
            this.customerService = customerService;
            this.userService = userService;
            this.facebookClient = facebookClient;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<EntityResult<JwtModel>> LoginAsync(LoginModel model)
        {
            var result = new EntityResult<JwtModel>();
            var loginResult = await signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            if (!loginResult.Succeeded)
            {
                result.AddError("usuario o contraseña incorrectos.", 403);
                return result;
            }

            var user = await userManager.FindByEmailAsync(model.Username);
            var refreshToken = await GenerateRefreshToken(model.Username);

            result.Entity = GenerateJwt(jwtFactory.GenerateClaimsIdentity(user.UserName, user.Id, "Customer"), user.UserName, refreshToken);

            return result;
        }

        public async Task<EntityResult<JwtModel>> GenerateJwtFromFacebookAsync(FacebookAuthViewModel model)
        {
            var result = new EntityResult<JwtModel>();
            // 1.generate an app access token
            var appAccessTokenResponse = await facebookClient.GenerateAppAccessTokenAsync();
            var appAccessToken = JsonConvert.DeserializeObject<FacebookAppAccessToken>(appAccessTokenResponse);
            // 2. validate the user access token
            var userAccessTokenValidationResponse = await facebookClient.ValidateUserAccessTokenAsync(model.AccessToken, appAccessToken.AccessToken);
            var userAccessTokenValidation = JsonConvert.DeserializeObject<FacebookUserAccessTokenValidation>(userAccessTokenValidationResponse);

            if (!userAccessTokenValidation.Data.IsValid)
            {
                //TODO: Add error to result.
            }

            // 3. we've got a valid token so we can request user data from fb
            var userInfoResponse = await facebookClient.GetUserInfoAsync(model.AccessToken);
            var userInfo = JsonConvert.DeserializeObject<FacebookUserData>(userInfoResponse);

            // 4. ready to create the local user account (if necessary) and jwt
            var customer = customerService.GetByEmailAsync(userInfo.Email).Result.Entity;

            if (customer == null)
            {
                var user = new CustomerCreateUpdateModel
                {
                    FirstName = userInfo.FirstName,
                    LastName = userInfo.LastName,
                    FacebookId = userInfo.Id,
                    Email = userInfo.Email,
                    UserName = userInfo.Email,
                    Gender = userInfo.Gender
                };

                await customerService.CreateAsync(user);

                customer = customerService.GetByEmailAsync(userInfo.Email).Result.Entity;
            }
            
            if (customer == null)
            {
                // TODO: Add error to result.
            }
            var refreshToken = await GenerateRefreshToken(customer.Email);

            result.Entity = GenerateJwt(jwtFactory.GenerateClaimsIdentity(customer.UserName, customer.UserId, "Customer"), customer.UserName, refreshToken);

            return result;
        }

        private JwtModel GenerateJwt(ClaimsIdentity identity, string userName, string refreshToken)
        {
            return new JwtModel
            {
                UserName = identity.Claims.SingleOrDefault(c => c.Type == "id").Value,
                AuthToken = jwtFactory.GenerateEncodedToken(userName, identity),
                RefreshToken = refreshToken,
                ExpiresIn = (int)jwtOptions.ValidFor.TotalSeconds
            };
        }
        private async Task<JwtModel> GenerateJwtAsync(UserModel user)
        {
            var refreshToken = await GenerateRefreshToken(user.UserName);
            return GenerateJwt(jwtFactory.GenerateClaimsIdentity(user), user.UserName, refreshToken);
        }
        
        private async Task<JwtModel> GenerateJwtFromUserNameAsync(string email)
        {
            var user = userService.GetByEmailAsync(email).Result.Entity;

            return await GenerateJwtAsync(user);
        }

        public async Task<EntityResult<JwtModel>> RefreshTokenAsync(RefreshTokenModel model)
        {
            var result = new EntityResult<JwtModel>();
            var principal = new ClaimsPrincipal();

            try
            {
                principal = GetPrincipalFromExpiredToken(model.AuthToken);
            }
            catch (SecurityTokenException ex)
            {
                result.AddError("Invalid Token");
            }

            var username = principal.FindFirst(ClaimTypes.NameIdentifier).Value;
            var savedRefreshToken = await userService.GetRefreshTokenAsync(username);

            if (savedRefreshToken != model.RefreshToken)
            {
                result.AddError("Invalid Refresh Token");
                return result;
            }

            var newJwtToken = await GenerateJwtFromUserNameAsync(username);

            result.Entity = newJwtToken;
            return result;
        }

        private async Task<string> GenerateRefreshToken(string email)
        {
            var refreshToken = string.Empty;
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                refreshToken = Convert.ToBase64String(randomNumber);
            }

            await userService.CreateRefreshTokenAsync(email, refreshToken);

            return refreshToken;
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtOptions.Issuer,
                ValidAudience = jwtOptions.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
            if (!(securityToken is JwtSecurityToken jwtSecurityToken) || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }
    }
}
