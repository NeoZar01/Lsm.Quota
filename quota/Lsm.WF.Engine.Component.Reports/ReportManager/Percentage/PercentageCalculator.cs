using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimpEduPlugInApplications.ReportManager.Percentage
{

    public class PercentageCalculator : PercentageReportBuilder
    {


        public PercentageCalculator()
        {

            percentage = new Percentage();
        }

        public override void CalculatePercentage(double a, double b)
        {
            try
            {
                double k = a / b;
                percentage["p"] = Math.Round((double)(k * 100), 1, MidpointRounding.AwayFromZero);
            }
            catch
            {
                percentage["p"] = 0;
            }

        }

        public override void SetDemoninatorOperand(double a)
        {
            percentage["d"] = a;
        }

        public override void SetNominatorOperand(double a)
        {
            percentage["n"] = a;
        }
    }
}
