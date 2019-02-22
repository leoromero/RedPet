using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RedPet.Common.Auth.Models;
using RedPet.Common.Models.Base;
using RedPet.Common.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RedPet.Core.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IJwtFactory jwtFactory;
        private readonly JwtIssuerOptions jwtOptions;
        private readonly ICustomerService customerService;
        private readonly IFacebookClient facebookClient;

        public AuthService( IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions, ICustomerService customerService, IFacebookClient facebookClient)
        {
            this.jwtFactory = jwtFactory;
            this.jwtOptions = jwtOptions.Value;
            this.customerService = customerService;
            this.facebookClient = facebookClient;
        }

        public EntityResult<JwtModel> GenerateGenericJwt()
        {
            var result = new EntityResult<JwtModel>();
            
            result.Entity = GenerateJwt(jwtFactory.GenerateClaimsIdentity("leo", "123"), "leo", jwtOptions, new JsonSerializerSettings { Formatting = Formatting.None });

            return result;
        }

        public JwtModel GenerateJwt(ClaimsIdentity identity, string userName, JwtIssuerOptions jwtOptions, JsonSerializerSettings serializerSettings)
        {
            return new JwtModel
            {
                Id = identity.Claims.SingleOrDefault(c => c.Type == "id").Value,
                AuthToken = jwtFactory.GenerateEncodedToken(userName, identity),
                ExpiresIn = (int)jwtOptions.ValidFor.TotalSeconds
            };
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
            var customer = await customerService.GetByEmailAsync(userInfo.Email);

            if (customer == null)
            {
                var user = new CustomerModel
                {
                    FirstName = userInfo.FirstName,
                    LastName = userInfo.LastName,
                    FacebookId = userInfo.Id,
                    Email = userInfo.Email,
                    UserName = userInfo.Email,
                    Gender = userInfo.Gender
                };

                await customerService.CreateAsync(user);
            }

            // generate the jwt for the local user...
            var localUser = customerService.GetByEmailAsync(userInfo.Email).Result.Entity;

            if (localUser == null)
            {
                // TODO: Add error to result.
            }

            result.Entity = GenerateJwt(jwtFactory.GenerateClaimsIdentity(localUser.UserName, localUser.UserId), localUser.UserName, jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });

            return result;
        }
    }
}
