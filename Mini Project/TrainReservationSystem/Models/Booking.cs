using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainReservationSystem.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime TravelDate { get; set; }
        public int TrainNo { get; set; }
        public string TravelClass { get; set; }
        public int PassengerCount { get; set; }
        public decimal Amount { get; set; }
    }
}
