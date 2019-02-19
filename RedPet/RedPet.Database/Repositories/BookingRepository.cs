
using System;
using System.Collections.Generic;
using System.Text;
using RedPet.Database.Entities;

namespace RedPet.Database.Repositories
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(RedPetContext context) : base(context)
        {
        }
    }

    public interface IBookingRepository : IRepository<Booking>
    {
    }
}
