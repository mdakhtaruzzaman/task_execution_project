using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPerformer.Model;

namespace TaskPerformer.ComplianceService
{
    internal class Female50PercentCompliance : IComplianceExecutor
    {
        private CompanyData companyData;
        public Female50PercentCompliance(CompanyData companyData)
        {
            this.companyData = companyData;
        }
        public async Task Execute()
        {
            try
            {
                var parcentValue = (Convert.ToDecimal(companyData.FemaleEmp) / Convert.ToDecimal(companyData.NumberOfEmp)) * 100;
                if (parcentValue >= 50)
                {
                    Console.WriteLine("Female50Percent: Compliance Passed");
                }
                else
                {
                    Console.WriteLine("Female50Percent: Compliance Failed");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
