using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPerformer.Model;

namespace TaskPerformer.Repo
{
    internal class StateComplianceRepo
    {
        List<StateCompliance> stateCompliances = new List<StateCompliance>();
        public StateComplianceRepo()
        {
        }
        public List<StateCompliance> GetStateCompliance()
        {
            ComplianceRepo complianceRepo = new ComplianceRepo();
            var compliances = complianceRepo.GetCompliance();

            stateCompliances.Add(new StateCompliance
            {
                State = "Alabama",
                Compliances = compliances.Where(_ => new List<int> { 1, 2, 3 }.Contains(_.Id)).ToList()
            });
            stateCompliances.Add(new StateCompliance
            {
                State = "Alaska",
                Compliances = compliances.Where(_ => new List<int> { 3, 4, 5 }.Contains(_.Id)).ToList()
            });
            return stateCompliances;
        }
    }
}
