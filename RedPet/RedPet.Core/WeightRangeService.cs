using AutoMapper;
using RedPet.Core.Base;
using RedPet.Database;
using RedPet.Database.Entities;
using RedPet.Database.Repositories;
using RedPet.Common.Models.Service;
using RedPet.Common.Models.Pet;

namespace RedPet.Core
{
    public class WeightRangeService : CrudService<WeightRange, WeightRangeModel>, IWeightRangeService
    {
        public WeightRangeService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, unitOfWork.GetRepository<IWeightRangeRepository>(), mapper)
        {
        }
    }

    public interface IWeightRangeService : ICrudService<WeightRange, WeightRangeModel>
    {
    }
}