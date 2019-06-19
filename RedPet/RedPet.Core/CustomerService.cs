using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RedPet.Common.Extensions;
using RedPet.Common.Models.Base;
using RedPet.Common.Models.Pet;
using RedPet.Common.Models.User;
using RedPet.Core.Base;
using RedPet.Database;
using RedPet.Database.Entities;
using RedPet.Database.Entities.Identity;
using RedPet.Database.Repositories;

namespace RedPet.Core
{
    public class CustomerService : CrudService<Customer, CustomerModel, CustomerCreateUpdateModel>, ICustomerService
    {
        private readonly ICustomerRepository repository;
        private readonly IUserService userService;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper,
            IUserService userService)
            : base(unitOfWork, unitOfWork.GetRepository<ICustomerRepository>(), mapper)
        {
            repository = (ICustomerRepository)Repository;
            this.userService = userService;
        }

        public override async Task<EntityResult<int>> CreateAsync(CustomerCreateUpdateModel model)
        {
            var result = new EntityResult<int>();
            
            var user = Mapper.Map<UserCreateUpdateModel>(model);
            user.Role = "Customer";
            result = await userService.CreateUserAsync(user);
                        
            if(!result.IsValid)
            {
                return result;
            }

            model.UserId = result.Entity;

            return await base.CreateAsync(model);
        }

        public async Task<EntityResult<CustomerModel>> GetByEmailAsync(string email)
        {
            var result = new EntityResult<CustomerModel>();
            var customer = await repository.GetByEmailAsync(email);
            result.Entity = Mapper.Map<CustomerModel>(customer);
            return result;
        }

        public async Task<EntityResult<List<PetModel>>> GetPetsAsync(int userId)
        {
            var result = new EntityResult<List<PetModel>>();
            var pets = await repository.GetPetsAsync(userId);
            result.Entity = Mapper.Map<List<PetModel>>(pets);
            return result;
        }
    }

    public interface ICustomerService : ICrudService<Customer, CustomerModel, CustomerCreateUpdateModel>
    {
        Task<EntityResult<List<PetModel>>> GetPetsAsync(int userId);
        Task<EntityResult<CustomerModel>> GetByEmailAsync(string email);
    }
}