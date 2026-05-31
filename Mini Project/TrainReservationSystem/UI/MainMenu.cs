using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainReservationSystem.Services;

namespace TrainReservationSystem.UI
{
    public class MainMenu
    {
        public void Start()
        {
            LoginService loginService = new LoginService();

            while (true)
            {
                Console.WriteLine("\n=================================");
                Console.WriteLine(" TRAIN RESERVATION SYSTEM ");
                Console.WriteLine("=================================");

                Console.Write("Username : ");
                string username = Console.ReadLine();

                Console.Write("Password : ");
                string password = Console.ReadLine();

                string role = loginService.Login(username, password);

                if (role == "Admin")
                {
                    Console.WriteLine("\nAdmin Login Successful");

                    AdminMenu admin = new AdminMenu();

                    admin.Show();
                }
                else if (role == "User")
                {
                    Console.WriteLine("\nUser Login Successful");

                    UserMenu user = new UserMenu();

                    user.Show();
                }
                else
                {
                    Console.WriteLine("\nInvalid Username or Password");
                }
            }
        }
    }
}
