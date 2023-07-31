using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPerformer.Model;

namespace TaskPerformer.Repo
{
    internal class ComplianceRepo
    {
        List<Compliance> compliances = new List<Compliance>();
        public ComplianceRepo()
        {
            compliances.Add(new Compliance { Id = 1, Name = "Company Size Compliance" });
            compliances.Add(new Compliance { Id = 2, Name = "Female 30% Count Compliance" });
            compliances.Add(new Compliance { Id = 3, Name = "Male 50% Count Compliance" });
            compliances.Add(new Compliance { Id = 4, Name = "Female 50% Count Compliance" });
            compliances.Add(new Compliance { Id = 5, Name = "30% Above 50 Compliance" });
        }
        public List<Compliance> GetCompliance()
        {
            return compliances;
        }
    }
}
