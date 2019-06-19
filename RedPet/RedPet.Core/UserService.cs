using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RedPet.Common.Auth.Models;
using RedPet.Common.Extensions;
using RedPet.Common.Models.Base;
using RedPet.Common.Models.User;
using RedPet.Core.Base;
using RedPet.Database;
using RedPet.Database.Entities.Identity;
using RedPet.Database.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace RedPet.Core
{
    public class UserService : CrudService<User, UserModel, UserCreateUpdateModel>, IUserService
    {
        private readonly IUserRepository repository;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
            : base(unitOfWork, unitOfWork.GetRepository<IUserRepository>(), mapper)
        {
            repository = (IUserRepository)Repository;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<EntityResult<int>> CreateUserAsync(UserCreateUpdateModel model)
        {
            var result = new EntityResult<int>();
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                result.AddError("Email", "El email ingresado ya esta registrado.", 409);
                return result;
            }

            user = Mapper.Map<User>(model);
            var userResult = await userManager.CreateAsync(user);

            if (!userResult.Succeeded)
            {
                foreach (var error in userResult.Errors)
                {
                    result.AddError(error.Description);
                }
                return result;
            }

            userResult = await userManager.AddToRoleAsync(user, !string.IsNullOrEmpty(model.Role)? model.Role : "Customer");

            if (!userResult.Succeeded)
            {
                await userManager.DeleteAsync(user);
                foreach (var error in userResult.Errors)
                {
                    result.AddError(error.Description);
                }
                return result;
            }

            userResult = await userManager.AddPasswordAsync(user, model.Password);

            if (!userResult.Succeeded)
            {
                await userManager.DeleteAsync(user);
                foreach (var error in userResult.Errors)
                {
                    result.AddError(error.Description);
                }
                return result;
            }

            result.Entity = GetByEmailAsync(model.Email).Result.Entity.Id;
            return result;
        }

        public async Task CreateRefreshTokenAsync(string email, string refreshToken)
        {
            var user = await repository.GetByEmailAsync(email);
            user.RefreshToken = refreshToken;

            await UnitOfWork.Complete();
        }

        public async Task<EntityResult<UserModel>> GetByEmailAsync(string email)
        {
            var result = new EntityResult<UserModel>();
            var user = await userManager.FindByEmailAsync(email);
            var userRoles = await userManager.GetRolesAsync(user);
            user.Role = userRoles.FirstOrDefault();
            result.Entity = Mapper.Map<UserModel>(user);

            return result;
        }

        public async Task<string> GetRefreshTokenAsync(string email)
        {
            var user = await repository.GetByEmailAsync(email);
            return user.RefreshToken;
        }

        public async Task<EntityResult<EmailModel>> ValidateEmailAsync(string email)
        {
            var result = new EntityResult<EmailModel>();
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                result.AddError("Email no encontrado", 404);
                return result;
            }

            result.Entity.Email = email;
            return result;
        }
    }

    public interface IUserService : ICrudService<User, UserModel, UserCreateUpdateModel>
    {
        Task CreateRefreshTokenAsync(string username, string refreshToken);
        Task<string> GetRefreshTokenAsync(string username);
        Task<EntityResult<UserModel>> GetByEmailAsync(string email);
        Task<EntityResult<int>> CreateUserAsync(UserCreateUpdateModel model);
        Task<EntityResult<EmailModel>> ValidateEmailAsync(string email);
    }
}