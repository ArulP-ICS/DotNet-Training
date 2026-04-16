using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{

    class Program
    {
        static void Main()
        {
            Console.Write("Enter number of matches played: ");
            int matches = Convert.ToInt32(Console.ReadLine());

            CricketTeam team = new CricketTeam();
            team.Pointscalculation(matches);

            Console.ReadLine();
        }
    }

    class CricketTeam
    {
        public void Pointscalculation(int no_of_matches)
        {

            int sum = 0;
            int score;


            for (int i = 1; i <= no_of_matches; i++)
            {
                Console.Write("Enter score for match " + i + ": ");
                score = int.Parse(Console.ReadLine());
                sum += score;
            }


            double average = (double)sum / no_of_matches;

            Console.WriteLine("\n--- IPL Team Statistics ---");
            Console.WriteLine("Total Matches Played: " + no_of_matches);
            Console.WriteLine("Sum of Points: " + sum);
            Console.WriteLine("Average Points: " + average);

        }
    }


}
