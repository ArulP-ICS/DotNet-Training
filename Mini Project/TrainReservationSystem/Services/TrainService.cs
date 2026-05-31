using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainReservationSystem.Repositories;

namespace TrainReservationSystem.Services
{
    public class TrainService
    {
        TrainRepository repo = new TrainRepository();

        public void ViewTrains()
        {
            repo.ViewTrains();
        }

        public void AddTrain()
        {
            repo.AddTrain();
        }

        public void UpdateTrain()
        {
            repo.UpdateTrain();
        }

        public void DeleteTrain()
        {
            repo.SoftDeleteTrain();
        }
    }
}
