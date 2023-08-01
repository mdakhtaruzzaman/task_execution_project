using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPerformer.Model;

namespace TaskPerformer.ComplianceService
{
    internal class Age30PercemtAbove50Compliance : IComplianceExecutor
    {
        private CompanyData companyData;
        public Age30PercemtAbove50Compliance(CompanyData companyData)
        {
            this.companyData = companyData;
        }
        public async Task Execute()
        {
            try
            {
                var parcentValue = (Convert.ToDecimal(companyData.Above50Age) / Convert.ToDecimal(companyData.NumberOfEmp)) * 100;
                if (parcentValue >= 30)
                {
                    Console.WriteLine("Age30PercemtAbove50: Compliance Passed");
                }
                else
                {
                    Console.WriteLine("Age30PercemtAbove50: Compliance Failed");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
