using DocumentFormat.OpenXml.Office2016.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPerformer.Model;

namespace TaskPerformer.ComplianceService
{
    internal class ProcessExecutor : ProcessHandler
    {
        private readonly Process _process;
        public ProcessExecutor(Process process)
        {
            this._process = process;
        }
        public override void HandleTask(ProcessData processData)
        {
            try
            {
                // code for:  check request from db its completed or not
                // code for:  if not completed
                var random = new Random();
                var successornot = random.Next(10) % 2 == 0 ?"Done":"Not Done";
                Console.WriteLine($"Process: {_process.Name} started!");
                Console.WriteLine($"Process: {_process.Name} {successornot}");
                Console.WriteLine($"Process: {_process.Name} started!");

                // code for: update request as completed into db
                _handler?.HandleTask(processData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
