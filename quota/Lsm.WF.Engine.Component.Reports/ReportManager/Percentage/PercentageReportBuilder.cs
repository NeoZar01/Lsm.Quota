using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimpEduPlugInApplications.ReportManager.Percentage
{

    public abstract class PercentageReportBuilder
    {
        public Percentage percentage; //tailor made for percentage calculations

        public Percentage Percentage { get { return percentage; } }

        public abstract void SetNominatorOperand(double a);
        public abstract void SetDemoninatorOperand(double a);
        public abstract void CalculatePercentage(double a, double b);

    }
}
