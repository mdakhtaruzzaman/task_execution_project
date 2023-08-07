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

            var stateConfigurations = GetStateConfigurations(compliances);

            foreach (var stateConfig in stateConfigurations)
            {
                var stateCompliance = new StateCompliance
                {
                    State = stateConfig.State,
                    Compliances = stateConfig.Compliances
                };

                stateCompliance.TaskHandler = BuildTaskHandler(stateCompliance.Compliances);

                stateCompliances.Add(stateCompliance);
            }

            return stateCompliances;
        }
        private TaskHandler BuildTaskHandler(List<Compliance> compliances)
        {
            TaskHandler handler = null;
            TaskHandler currentHandler = null;

            foreach (var compliance in compliances)
            {
                var taskExecutor = new TaskExecutor(compliance);
                if (handler == null)
                {
                    handler = taskExecutor;
                    currentHandler = handler;
                }
                else
                {
                    currentHandler?.SetNext(taskExecutor);
                    currentHandler = taskExecutor;
                }
            }
            return handler;
        }

        private List<StateCompliance> GetStateConfigurations(List<Compliance> compliances)
        {
            // Define state-specific compliance configurations here
            var stateConfigurations = new List<StateCompliance>
            {
                new StateCompliance
                {
                    State = "Alabama",
                    Compliances = compliances.Where(c => new List<int> { 1, 2, 3 }.Contains(c.Id)).ToList()
                },
                new StateCompliance
                {
                    State = "Alaska",
                    Compliances = compliances.Where(c => new List<int> { 3, 4, 5 }.Contains(c.Id)).ToList()
                },
                // Add more configurations as needed
            };
            return stateConfigurations;
        }
    }
}
