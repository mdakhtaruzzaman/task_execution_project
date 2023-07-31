using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPerformer.Model
{
    public class CompanyData
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string CompanyName { get; set; }
        public int NumberOfEmp { get; set; }
        public int MaleEmp { get; set; }
        public int FemaleEmp { get; set; }
        public int Above50Age { get; set; }
    }
}
