using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RedPet.Common.Models.Base;
using RedPet.Common.Models.Pet;
using RedPet.Common.Models.User;
using RedPet.Core.Base;
using RedPet.Database;
using RedPet.Database.Entities;
using RedPet.Database.Repositories;

namespace RedPet.Core
{
    public class CustomerService : CrudService<Customer, CustomerModel, CustomerModel, CustomerModel>, ICustomerService
    {
        private readonly ICustomerRepository repository;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, unitOfWork.GetRepository<ICustomerRepository>(), mapper)
        {
            repository = (ICustomerRepository)Repository;
        }

        public async Task<EntityResult<CustomerModel>> GetByEmailAsync(string email)
        {
            var result = new EntityResult<CustomerModel>();
            var customer = await repository.GetByEmailAsync(email);
            result.Entity = Mapper.Map<CustomerModel>(customer);
            return result;
        }

        public async Task<EntityResult<List<PetModel>>> GetPetsAsync(string userName)
        {
            var result = new EntityResult<List<PetModel>>();
            var pets = await repository.GetPetsAsync(userName);
            result.Entity = Mapper.Map<List<PetModel>>(pets);
            return result;
        }
    }

    public interface ICustomerService : ICrudService<Customer, CustomerModel, CustomerModel, CustomerModel>
    {
        Task<EntityResult<List<PetModel>>> GetPetsAsync(string userName);
        Task<EntityResult<CustomerModel>> GetByEmailAsync(string email);
    }
}