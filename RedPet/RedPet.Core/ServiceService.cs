using AutoMapper;
using RedPet.Core.Base;
using RedPet.Database;
using RedPet.Database.Entities;
using RedPet.Database.Repositories;
using RedPet.Common.Models.Service;
using RedPet.Common.Models.Base;
using System.Threading.Tasks;
using System.Collections.Generic;
using RedPet.Common.Models.ServiceSearch;

namespace RedPet.Core
{
    public class ServiceService : CrudService<Service, ServiceModel, ServiceCreateUpdateModel>, IServiceService
    {
        private readonly IProviderRepository providerRepository;

        public ServiceService(IUnitOfWork unitOfWork, IMapper mapper, IProviderRepository providerRepository)
            : base(unitOfWork, unitOfWork.GetRepository<IServiceRepository>(), mapper)
        {
            this.providerRepository = providerRepository;
        }

        public override async Task<EntityResult<int>> CreateAsync(ServiceCreateUpdateModel model)
        {
            var result = new EntityResult<int>();
            var provider = await providerRepository.GetByUserIdAsync(model.UserId);
            var service = Mapper.Map<Service>(model);
            service.ProviderId = provider.Id;

            Repository.Create(service);
            await UnitOfWork.Complete();
            result.Entity = service.Id;

            return result;
        }

        public async Task<EntityResult<ServiceSearchResultModel>> SearchServicesAsync(ServiceSearchModel parameters)
        {
            var result = new EntityResult<ServiceSearchResultModel>();

            var services = await Repository.SearchAsync(parameters);
        }
    }

    public interface IServiceService : ICrudService<Service, ServiceModel, ServiceCreateUpdateModel>
    {
    }
}