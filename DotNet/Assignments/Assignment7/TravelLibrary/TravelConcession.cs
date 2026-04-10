using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelLibrary
{
    public class TravelConcession
    {
        public string CalculateConcession(int age, int totalFare)
        {
            if (age <= 5)
            {
                return "Little Champs - Free Ticket";
            }
            else if (age > 60)
            {
                double discountedFare = totalFare - (0.30 * totalFare);
                return "Senior Citizen - Fare: " + discountedFare;
            }
            else
            {
                return "Ticket Booked - Fare: " + totalFare;
            }
        }
    }
}