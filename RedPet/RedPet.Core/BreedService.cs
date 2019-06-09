using AutoMapper;
using RedPet.Core.Base;
using RedPet.Database;
using RedPet.Database.Entities;
using RedPet.Database.Repositories;
using RedPet.Common.Models.Booking;
using RedPet.Common.Models.Pet;

namespace RedPet.Core
{
    public class BreedService : CrudService<Breed, BreedModel>, IBreedService
    {
        public BreedService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, unitOfWork.GetRepository<IBreedRepository>(), mapper)
        {
        }
    }

    public interface IBreedService : ICrudService<Breed, BreedModel>
    {
    }
}