using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment4.Reports
{

    public class SummaryReport : IReport
    {
        public void Generate()
        {
            Console.WriteLine("Generating Summary Report...");
        }
    }

}
