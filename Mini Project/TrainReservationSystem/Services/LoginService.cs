using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainReservationSystem.Repositories;

namespace TrainReservationSystem.Services
{
    public class LoginService
    {
        UserRepository repo = new UserRepository();

        public string Login(string username, string password)
        {
            return repo.Login(username, password);
        }
    }
}
