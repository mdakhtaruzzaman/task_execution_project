using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TaskPerformer.ComplianceService
{
    internal class Invoker
    {
        private IComplianceExecutor executor;

        public void SetCommand(IComplianceExecutor executor)
        {
            this.executor = executor;
        }

        public void ExecuteTask()
        {
            executor.Execute();
        }

    }
}
