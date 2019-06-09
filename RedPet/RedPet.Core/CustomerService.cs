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
    public class CustomerService : CrudService<Customer, CustomerModel>, ICustomerService
    {
        private readonly ICustomerRepository repository;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper,
            UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
            : base(unitOfWork, unitOfWork.GetRepository<ICustomerRepository>(), mapper)
        {
            repository = (ICustomerRepository)Repository;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public override async Task<EntityResult<int>> CreateAsync(CustomerModel model)
        {
            var errorResult = new EntityResult<int>();
            var user = Mapper.Map<User>(model);
            var role = await roleManager.FindByNameAsync("Customer");
            var identityResult = await userManager.CreateAsync(user);

            if (!identityResult.Succeeded)
            {
                identityResult.Errors.ToList().ForEach(e => errorResult.AddError($"{e.Code} - {e.Description}"));
                return errorResult;
            }

            identityResult = await userManager.AddToRoleAsync(user, role.Name);

            if (!identityResult.Succeeded)
            {
                identityResult.Errors.ToList().ForEach(e => errorResult.AddError($"{e.Code} - {e.Description}"));
                return errorResult;
            }

            model.UserId = user.Id;

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

    public interface ICustomerService : ICrudService<Customer, CustomerModel>
    {
        Task<EntityResult<List<PetModel>>> GetPetsAsync(int userId);
        Task<EntityResult<CustomerModel>> GetByEmailAsync(string email);
    }
}