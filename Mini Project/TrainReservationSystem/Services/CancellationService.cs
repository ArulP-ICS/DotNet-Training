using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainReservationSystem.Repositories;

namespace TrainReservationSystem.Services
{
    public class CancellationService
    {
        CancellationRepository repo = new CancellationRepository();

        public void CancelTicket()
        {
            repo.CancelTicket();
        }

        public void ViewCancellationDetails()
        {
            repo.ViewCancellationDetails();
        }
    }
}
