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
    internal abstract class TaskHandler 
    {
        protected TaskHandler _handler;
        public TaskHandler SetNext(TaskHandler handler)
        {
            this._handler = handler;
            return handler;
        }
        public abstract void HandleTask(CompanyData companyData);
    }
}
