using LimpEduPlugInApplications.ReportManager.Percentage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimpEduPlugInApplications.ReportManager
{
     public class StatisticsServiceManager
    {
            /*
                  --> Calculates percentage and returns PercentageMetrics as a report template.
            */
            public virtual void CalculatePercentage(PercentageReportBuilder report, double a, double b)
            {
                report.SetNominatorOperand(a);
                report.SetDemoninatorOperand(b);
                report.CalculatePercentage(a, b);
            }
    }
}
