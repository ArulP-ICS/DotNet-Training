using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainReservationSystem.Services;

namespace TrainReservationSystem.UI
{
    public class AdminMenu
    {
        public void Show()
        {
            TrainService trainService = new TrainService();

            BookingService bookingService = new BookingService();

            CancellationService cancelService = new CancellationService();

            while (true)
            {
                Console.WriteLine("\n=================================");
                Console.WriteLine(" ADMIN MENU ");
                Console.WriteLine("=================================");

                Console.WriteLine("1. View Trains");
                Console.WriteLine("2. Add Train");
                Console.WriteLine("3. Update Train");
                Console.WriteLine("4. Delete Train");
                Console.WriteLine("5. View Bookings");
                Console.WriteLine("6. View Cancellations");
                Console.WriteLine("7. Logout");

                Console.Write("\nEnter Choice : ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        trainService.ViewTrains();
                        break;

                    case 2:
                        trainService.AddTrain();
                        break;

                    case 3:
                        trainService.UpdateTrain();
                        break;

                    case 4:
                        trainService.DeleteTrain();
                        break;

                    case 5:
                        bookingService.ViewBookings();
                        break;

                    case 6:
                        cancelService.ViewCancellationDetails();
                        break;

                    case 7:
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
