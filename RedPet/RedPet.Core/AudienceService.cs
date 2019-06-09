using AutoMapper;
using RedPet.Core.Base;
using RedPet.Database;
using RedPet.Database.Entities;
using RedPet.Database.Repositories;
using RedPet.Common.Models.Service;
using RedPet.Common.Models.Promotion;

namespace RedPet.Core
{
    public class AudienceService : CrudService<Audience, AudienceModel, AudienceCreateUpdateModel>, IAudienceService
    {
        public AudienceService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, unitOfWork.GetRepository<IAudienceRepository>(), mapper)
        {
        }
    }

    public interface IAudienceService : ICrudService<Audience, AudienceModel, AudienceCreateUpdateModel>
    {
    }
}