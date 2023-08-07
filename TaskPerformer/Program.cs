// See https://aka.ms/new-console-template for more information
using System.Linq.Expressions;
using System.Windows.Input;
using TaskPerformer;
using TaskPerformer.ComplianceService;
using TaskPerformer.Model;
using TaskPerformer.Repo;


class Program
{
    static async Task Main()
    {

        StateComplianceRepo complianceRepo = new StateComplianceRepo();
        var stateCompliances = complianceRepo.GetStateCompliance();

        Console.WriteLine("############################ Report  ############################");
        FileReader fileReader = new FileReader();
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "res", "MOCK_DATA.xlsx");
        if (File.Exists(filePath))
        {
            var data = fileReader.Read(filePath);
            foreach (var companyData in data)
            {
                Console.WriteLine("############################### Start ###########################");
                Console.WriteLine($"ID: {companyData.Id}\tCompany Name: {companyData.CompanyName}\tState: {companyData.State}\tTotal Emp: {companyData.NumberOfEmp}\tMale Emp: {companyData.MaleEmp}\tFemale Emp: {companyData.FemaleEmp}\tAbove 50 Age: {companyData.Above50Age}");
                Console.WriteLine();

                var compliance = stateCompliances.Where(_=>_.State.Equals(companyData.State)).FirstOrDefault();
                compliance?.TaskHandler.HandleTask(companyData);

                Console.WriteLine();
                Console.WriteLine("################################ END ############################");
                Console.WriteLine();
            }
        }

        Console.ReadKey();
    }
}