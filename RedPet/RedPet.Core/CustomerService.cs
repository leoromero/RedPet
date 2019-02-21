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

        public async Task<EntityResult<IEnumerable<PetModel>>> GetPetsAsync(int userId)
        {
            var result = new EntityResult<IEnumerable<PetModel>>();
            var pets = await repository.GetPetsAsync(userId);
            result.Entity = Mapper.Map<IEnumerable<PetModel>>(pets);
            return result;
        }
    }

    public interface ICustomerService : ICrudService<Customer, CustomerModel, CustomerModel, CustomerModel>
    {
        Task<EntityResult<IEnumerable<PetModel>>> GetPetsAsync(int userId);
        Task<EntityResult<CustomerModel>> GetByEmailAsync(string email);
    }
}