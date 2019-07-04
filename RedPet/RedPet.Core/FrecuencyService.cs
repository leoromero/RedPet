using AutoMapper;
using RedPet.Core.Base;
using RedPet.Database;
using RedPet.Database.Entities;
using RedPet.Database.Repositories;
using RedPet.Common.Models.Service;

namespace RedPet.Core
{
    public class FrecuencyService : CrudService<Frecuency, FrecuencyModel>, IFrecuencyService
    {
        public FrecuencyService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, unitOfWork.GetRepository<IFrecuencyRepository>(), mapper)
        {
        }
    }

    public interface IFrecuencyService : ICrudService<Frecuency, FrecuencyModel>
    {
    }
}