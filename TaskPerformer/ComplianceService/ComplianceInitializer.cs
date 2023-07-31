using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPerformer.Model;

namespace TaskPerformer.ComplianceService
{
    internal class ComplianceInitializer
    {
        public void Init(Invoker invoker, Compliance compliance, CompanyData companyData)
        {
            switch (compliance.Id)
            {
                case 1:
                    invoker.SetCommand(new CompanySizeCompliance(companyData));
                    break;
                case 2:
                    invoker.SetCommand(new Female30PercentCompliance(companyData));
                    break;
                case 3:
                    invoker.SetCommand(new Male50PercentCompliance(companyData));
                    break;
                case 4:
                    invoker.SetCommand(new Female50PercentCompliance(companyData));
                    break;
                case 5:
                    invoker.SetCommand(new Age30PercemtAbove50Compliance(companyData));
                    break;
                default:
                    break;
            }

            // Invoker executes the command
            invoker.ExecuteTask();
        }
    }
}
