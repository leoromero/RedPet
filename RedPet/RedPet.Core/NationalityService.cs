using AutoMapper;
using RedPet.Core.Base;
using RedPet.Database;
using RedPet.Database.Entities;
using RedPet.Database.Repositories;
using RedPet.Common.Models.Booking;
using RedPet.Common.Models.Pet;
using RedPet.Common.Models.Provider;

namespace RedPet.Core
{
    public class NationalityService : CrudService<Nationality, NationalityModel>, INationalityService
    {
        public NationalityService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, unitOfWork.GetRepository<INationalityRepository>(), mapper)
        {
        }
    }

    public interface INationalityService : ICrudService<Nationality, NationalityModel>
    {
    }
}