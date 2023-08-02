using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPerformer.ComplianceService;

namespace TaskPerformer.Model
{
    internal class StateCompliance
    {
        public string State { get; set; }
        public List<Compliance> Compliances { get; set; }
        public TaskHandler TaskHandler { get; set; }
    }
}
