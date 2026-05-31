using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainReservationSystem.Services;

namespace TrainReservationSystem.UI
{
    public class UserMenu
    {
        public void Show()
        {
            TrainService trainService = new TrainService();

            BookingService bookingService = new BookingService();

            CancellationService cancelService = new CancellationService();

            while (true)
            {
                Console.WriteLine("\n=================================");
                Console.WriteLine(" USER MENU ");
                Console.WriteLine("=================================");

                Console.WriteLine("1. View Trains");
                Console.WriteLine("2. Book Ticket");
                Console.WriteLine("3. Cancel Ticket");
                Console.WriteLine("4. Logout");

                Console.Write("\nEnter Choice : ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        trainService.ViewTrains();
                        break;

                    case 2:
                        bookingService.BookTicket();
                        break;

                    case 3:
                        cancelService.CancelTicket();
                        break;

                    case 4:
                        Console.WriteLine("Logout Successful");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}
