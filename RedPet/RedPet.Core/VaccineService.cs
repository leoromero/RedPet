using AutoMapper;
using RedPet.Core.Base;
using RedPet.Database;
using RedPet.Database.Entities;
using RedPet.Database.Repositories;
using RedPet.Common.Models.Promotion;
using RedPet.Common.Models.Pet;

namespace RedPet.Core
{
    public class VaccineService : CrudService<Vaccine, VaccineModel>, IVaccineService
    {
        public VaccineService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, unitOfWork.GetRepository<IVaccineRepository>(), mapper)
        {
        }
    }

    public interface IVaccineService : ICrudService<Vaccine, VaccineModel>
    {
    }
}