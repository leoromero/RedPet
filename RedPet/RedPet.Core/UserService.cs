using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RedPet.Common.Models.Base;
using RedPet.Common.Models.User;
using RedPet.Core.Base;
using RedPet.Database;
using RedPet.Database.Entities.Identity;
using RedPet.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedPet.Core
{
    public class UserService : CrudService<User, UserModel>, IUserService
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
    }

    public interface IUserService : ICrudService<User, UserModel>
    {
        Task CreateRefreshTokenAsync(string username, string refreshToken);
        Task<string> GetRefreshTokenAsync(string username);
        Task<EntityResult<UserModel>> GetByEmailAsync(string email);
    }
}