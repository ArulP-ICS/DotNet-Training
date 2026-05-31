using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainReservationSystem.Repositories;

namespace TrainReservationSystem.Services
{
    public class BookingService
    {
        BookingRepository repo = new BookingRepository();

        public void BookTicket()
        {
            repo.BookTicket();
        }

        public void ViewBookings()
        {
            repo.ViewBookings();
        }
    }
}
