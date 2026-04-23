using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assessment4.Reports;

namespace Assessment4.Factory
{
    public class ReportFactory
    {
        public static IReport GetReport(string reportType)
        {
            switch (reportType.ToLower())
            {
                case "chart":
                    return new ChartReport();

                case "tabular":
                    return new TabularReport();

                case "summary":
                    return new SummaryReport();

                default:
                    return null;
            }
        }
    }
}
