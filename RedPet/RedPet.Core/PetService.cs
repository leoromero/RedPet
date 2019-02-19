using AutoMapper;
using RedPet.Core.Base;
using RedPet.Database;
using RedPet.Database.Entities;
using RedPet.Database.Repositories;
using RedPet.Model.Pet;

namespace RedPet.Core
{
    public class PetService : CrudService<Pet, PetModel, PetCreateUpdateModel, PetCreateUpdateModel>, IPetService
    {
        public PetService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, unitOfWork.GetRepository<IPetRepository>(), mapper)
        {
        }
    }

    public interface IPetService : ICrudService<Pet, PetModel, PetCreateUpdateModel, PetCreateUpdateModel>
    {
    }
}