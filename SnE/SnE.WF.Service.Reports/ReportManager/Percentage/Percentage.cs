using LimpEduPlugInApplications.ReportManager.Percentage.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimpEduPlugInApplications.ReportManager.Percentage
{
    public class Percentage
    {
        private  Dictionary<string, double> operands = new Dictionary<string, double>(); 

        public PercentageMetric GetMetric()
        {
            PercentageMetric metric = new PercentageMetric();
            metric.NominatorOperand = operands["n"];
            metric.DenominatorOperand = operands["d"];
            metric.Percentage = operands["p"];

            return metric;
        }
        public double this[string key] { get { return operands[key]; } set { operands[key] = value; } }
    }
}
