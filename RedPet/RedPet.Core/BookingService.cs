using AutoMapper;
using RedPet.Core.Base;
using RedPet.Database;
using RedPet.Database.Entities;
using RedPet.Database.Repositories;
using RedPet.Common.Models.Booking;

namespace RedPet.Core
{
    public class BookingService : CrudService<Booking, BookingModel, BookingCreateUpdateModel, BookingCreateUpdateModel>, IBookingService
    {
        public BookingService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, unitOfWork.GetRepository<IBookingRepository>(), mapper)
        {
        }
    }

    public interface IBookingService : ICrudService<Booking, BookingModel, BookingCreateUpdateModel, BookingCreateUpdateModel>
    {
    }
}