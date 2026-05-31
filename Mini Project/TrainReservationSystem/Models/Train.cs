using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainReservationSystem.Models
{
    public class Train
    {
        public int TrainNo { get; set; }

        public string TrainName { get; set; }

        public string FromStation { get; set; }

        public string ToStation { get; set; }

        public int Seats2AC { get; set; }

        public decimal Price2AC { get; set; }

        public int Seats3AC { get; set; }

        public decimal Price3AC { get; set; }

        public int SleeperSeats { get; set; }

        public decimal SleeperPrice { get; set; }

        public bool IsDeleted { get; set; }
    }
}