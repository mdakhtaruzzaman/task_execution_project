using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPerformer.ComplianceService
{
    internal interface IComplianceExecutor
    {
        Task Execute();
    }
}
