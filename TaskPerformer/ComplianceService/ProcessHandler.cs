using DocumentFormat.OpenXml.Office2016.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TaskPerformer.Model;

namespace TaskPerformer.ComplianceService
{
    internal abstract class ProcessHandler
    {
        protected ProcessHandler _handler;
        public ProcessHandler SetNext(ProcessHandler handler)
        {
            this._handler = handler;
            return handler;
        }
        public abstract void HandleTask(ProcessData processData);
    }
}
