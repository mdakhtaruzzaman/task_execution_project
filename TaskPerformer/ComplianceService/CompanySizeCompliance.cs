using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPerformer.Model;

namespace TaskPerformer.ComplianceService
{
    internal class CompanySizeCompliance : IComplianceExecutor
    {
        private CompanyData companyData;
        public CompanySizeCompliance(CompanyData companyData)
        {
            this.companyData = companyData;
        }
        public async Task Execute()
        {
            try
            {
                if(companyData.NumberOfEmp>100)
                {
                    Console.WriteLine("CompanySize: Compliance Passed");
                }
                else
                {
                    Console.WriteLine("CompanySize: Compliance Failed");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
