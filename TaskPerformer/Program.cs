// See https://aka.ms/new-console-template for more information
using System.Linq.Expressions;
using System.Windows.Input;
using TaskPerformer;
using TaskPerformer.ComplianceService;
using TaskPerformer.Model;
using TaskPerformer.Repo;

StateComplianceRepo complianceRepo = new StateComplianceRepo();
var stateCompliances = complianceRepo.GetStateCompliance();

//foreach (var compliance in stateCompliances)
//{
//    Console.WriteLine($"State Name: {compliance.State}");
//	foreach (var item in compliance.Compliances)
//	{
//        Console.WriteLine($"\tCompliance Name: {item.Name}");
//    }
//}



Console.WriteLine("############################ Report  ############################");
FileReader fileReader = new FileReader();
string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "res", "MOCK_DATA.xlsx");
if (File.Exists(filePath))
{
    var data = fileReader.Read(filePath);
    foreach (var single_data in data)
    {
        Console.WriteLine("############################### Start ###########################");
        Console.WriteLine("Company Name: " + single_data.CompanyName);
        Console.WriteLine($"State: {single_data.State}\tTotal Emp: {single_data.NumberOfEmp}\tMale Emp: {single_data.MaleEmp}\tFemale Emp: {single_data.FemaleEmp}\tAbove 50 Age: {single_data.Above50Age}");
        Console.WriteLine();
        // Client creates commands and associates them with the receiver
        IComplianceExecutor companySizeCompliance = new CompanySizeCompliance(single_data);
        IComplianceExecutor female30PercentCompliance = new Female30PercentCompliance(single_data);
        IComplianceExecutor male50PercentCompliance = new Male50PercentCompliance(single_data);
        IComplianceExecutor female50PercentCompliance = new Female50PercentCompliance(single_data);
        IComplianceExecutor age30PercemtAbove50Compliance = new Age30PercemtAbove50Compliance(single_data);

        // Client creates the invoker and associates it with the commands
        Invoker invoker = new Invoker();
        var stateCompliance = stateCompliances.Where(_ => _.State.Equals(single_data.State)).FirstOrDefault();
        foreach (var item in stateCompliance.Compliances)
        {
            switch (item.Id)
            {
                case 1:
                    invoker.SetCommand(companySizeCompliance);
                    break;
                case 2:
                    invoker.SetCommand(female30PercentCompliance);
                    break;
                case 3:
                    invoker.SetCommand(male50PercentCompliance);
                    break;
                case 4:
                    invoker.SetCommand(female50PercentCompliance);
                    break;
                case 5:
                    invoker.SetCommand(age30PercemtAbove50Compliance);
                    break;
                default:
                    break;
            }

            // Invoker executes the command
            invoker.ExecuteTask();
        }

        Console.WriteLine();
        Console.WriteLine("################################ END ############################");
    }
}

