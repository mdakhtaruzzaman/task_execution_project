using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPerformer.ComplianceService;
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

            // get state compliance
            stateCompliances.Add(new StateCompliance
            {
                State = "Alabama",
                Compliances = compliances.Where(_ => new List<int> { 1, 2, 3 }.Contains(_.Id)).ToList()
            });
            stateCompliances.Add(new StateCompliance
            {
                State = "Alaska",
                Compliances = compliances.Where(_ => new List<int> { 3, 4, 5 }.Contains(_.Id)).ToList(),
            });

            // set compliance handler
            foreach (var state in stateCompliances)
            {
                state.TaskHandler = new TaskExecutor(state.Compliances[0]);
                state.TaskHandler.SetNext(new TaskExecutor(state.Compliances[1])).SetNext(new TaskExecutor(state.Compliances[2]));
                //foreach (var item in state.Compliances)
                //{
                //    if (state.ComplianceHandler == null)
                //        state.ComplianceHandler = new SetCompliance(item);
                //    else
                //        state.ComplianceHandler.SetNext(new SetCompliance(item));
                //}
            }

            return stateCompliances;
        }
    }
}
