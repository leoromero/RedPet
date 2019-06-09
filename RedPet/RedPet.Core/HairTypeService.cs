using AutoMapper;
using RedPet.Core.Base;
using RedPet.Database;
using RedPet.Database.Entities;
using RedPet.Database.Repositories;
using RedPet.Common.Models.Booking;
using RedPet.Common.Models.Pet;

namespace RedPet.Core
{
    public class HairTypeService : CrudService<HairType, HairTypeModel>, IHairTypeService
    {
        public HairTypeService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, unitOfWork.GetRepository<IHairTypeRepository>(), mapper)
        {
        }
    }

    public interface IHairTypeService : ICrudService<HairType, HairTypeModel>
    {
    }
}