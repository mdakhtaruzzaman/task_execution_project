using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPerformer.Model;

namespace TaskPerformer.ComplianceService
{
    internal class Male50PercentCompliance : IComplianceExecutor
    {
        private CompanyData companyData;
        public Male50PercentCompliance(CompanyData companyData)
        {
            this.companyData = companyData;
        }
        public void Execute()
        {
            try
            {
                decimal parcentValue = (Convert.ToDecimal(companyData.MaleEmp) / Convert.ToDecimal(companyData.NumberOfEmp)) * 100;
                if (parcentValue >= 50)
                {
                    Console.WriteLine("Male50Percent: Compliance Passed");
                }
                else
                {
                    Console.WriteLine("Male50Percent: Compliance Failed");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
