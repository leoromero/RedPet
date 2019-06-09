using AutoMapper;
using RedPet.Core.Base;
using RedPet.Database;
using RedPet.Database.Entities;
using RedPet.Database.Repositories;
using RedPet.Common.Models.Service;

namespace RedPet.Core
{
    public class ServiceTypeService : CrudService<ServiceType, ServiceTypeModel>, IServiceTypeService
    {
        public ServiceTypeService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, unitOfWork.GetRepository<IServiceTypeRepository>(), mapper)
        {
        }
    }

    public interface IServiceTypeService : ICrudService<ServiceType, ServiceTypeModel>
    {
    }
}