using AutoMapper;
using RedPet.Common.Models.Provider;
using RedPet.Core.Base;
using RedPet.Database;
using RedPet.Database.Entities;
using RedPet.Database.Repositories;

namespace RedPet.Core
{
    public class IdentificationTypeService : CrudService<IdentificationType, IdentificationTypeModel>, IIdentificationTypeService
    {
        public IdentificationTypeService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, unitOfWork.GetRepository<IIdentificationTypeRepository>(), mapper)
        {
        }
    }

    public interface IIdentificationTypeService : ICrudService<IdentificationType, IdentificationTypeModel>
    {
    }
}