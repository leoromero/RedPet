using AutoMapper;
using RedPet.Core.Base;
using RedPet.Database;
using RedPet.Database.Entities;
using RedPet.Database.Repositories;
using RedPet.Common.Models.Service;

namespace RedPet.Core
{
    public class ServiceService : CrudService<Service, ServiceModel>, IServiceService
    {
        public ServiceService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, unitOfWork.GetRepository<IServiceRepository>(), mapper)
        {
        }
    }

    public interface IServiceService : ICrudService<Service, ServiceModel>
    {
    }
}