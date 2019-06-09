using System.Threading.Tasks;
using AutoMapper;
using RedPet.Common.Models.Base;
using RedPet.Common.Models.Pet;
using RedPet.Core.Base;
using RedPet.Database;
using RedPet.Database.Entities;
using RedPet.Database.Repositories;

namespace RedPet.Core
{
    public class PetSizeService : CrudService<PetSize, PetSizeModel>, IPetSizeService
    {
        public PetSizeService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, unitOfWork.GetRepository<IPetSizeRepository>(), mapper)
        {
        }
    }

    public interface IPetSizeService : ICrudService<PetSize, PetSizeModel>
    {
    }
}