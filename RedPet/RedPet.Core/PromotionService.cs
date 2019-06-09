using AutoMapper;
using RedPet.Core.Base;
using RedPet.Database;
using RedPet.Database.Entities;
using RedPet.Database.Repositories;
using RedPet.Common.Models.Promotion;

namespace RedPet.Core
{
    public class PromotionService : CrudService<Promotion, PromotionModel, PromotionCreateUpdateModel>, IPromotionService
    {
        public PromotionService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, unitOfWork.GetRepository<IPromotionRepository>(), mapper)
        {
        }
    }

    public interface IPromotionService : ICrudService<Promotion, PromotionModel, PromotionCreateUpdateModel>
    {
    }
}