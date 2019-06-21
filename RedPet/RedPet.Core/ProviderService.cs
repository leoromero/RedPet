using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RedPet.Common.Extensions;
using RedPet.Common.Models.Base;
using RedPet.Common.Models.Pet;
using RedPet.Common.Models.Provider;
using RedPet.Common.Models.Service;
using RedPet.Common.Models.User;
using RedPet.Core.Base;
using RedPet.Database;
using RedPet.Database.Entities;
using RedPet.Database.Entities.Identity;
using RedPet.Database.Repositories;

namespace RedPet.Core
{
    public class ProviderService : CrudService<Provider, ProviderModel, ProviderCreateUpdateModel>, IProviderService
    {
        private readonly IProviderRepository repository;
        private readonly IUserService userService;

        public ProviderService(IUnitOfWork unitOfWork, IMapper mapper,
            IUserService userService)
            : base(unitOfWork, unitOfWork.GetRepository<IProviderRepository>(), mapper)
        {
            repository = (IProviderRepository)Repository;
            this.userService = userService;
        }

        public override async Task<EntityResult<int>> CreateAsync(ProviderCreateUpdateModel model)
        {
            var result = new EntityResult<int>();
            
            var user = Mapper.Map<UserCreateUpdateModel>(model);
            user.Role = "Provider";
            result = await userService.CreateUserAsync(user);
                        
            if(!result.IsValid)
            {
                return result;
            }

            model.UserId = result.Entity;

            return await base.CreateAsync(model);
        }

        public async Task<EntityResult<ProviderModel>> GetByEmailAsync(string email)
        {
            var result = new EntityResult<ProviderModel>();
            var provider = await repository.GetByEmailAsync(email);
            result.Entity = Mapper.Map<ProviderModel>(provider);
            return result;
        }

        public async Task<EntityResult<List<ServiceModel>>> GetServicesAsync(int userId)
        {
            var result = new EntityResult<List<ServiceModel>>();
            var services = await repository.GetServicesAsync(userId);
            result.Entity = Mapper.Map<List<ServiceModel>>(services);
            return result;
        }
    }

    public interface IProviderService : ICrudService<Provider, ProviderModel, ProviderCreateUpdateModel>
    {
        Task<EntityResult<List<ServiceModel>>> GetServicesAsync(int userId);
        Task<EntityResult<ProviderModel>> GetByEmailAsync(string email);
    }
}