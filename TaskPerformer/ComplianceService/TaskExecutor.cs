using DocumentFormat.OpenXml.Office2016.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPerformer.Model;

namespace TaskPerformer.ComplianceService
{
    internal class TaskExecutor : TaskHandler
    {
        private readonly Compliance _compliance;
        public TaskExecutor(Compliance compliance)
        {
            this._compliance = compliance;
        }
        public override void HandleTask(CompanyData companyData)
        {
            try
            {
                // code for:  check request from db its completed or not
                // code for:  if not completed
                var random = new Random();
                var successornot = random.Next(10) % 2 == 0 ?"Done":"Not Done";
                Console.WriteLine($"Compliance: {_compliance.Name} started!");
                Console.WriteLine($"Compliance: {_compliance.Name} {successornot}");
                Console.WriteLine($"Compliance: {_compliance.Name} started!");

                // code for: update request as completed into db
                _handler?.HandleTask(companyData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
