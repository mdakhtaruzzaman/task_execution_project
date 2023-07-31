// See https://aka.ms/new-console-template for more information
using TaskPerformer;
using TaskPerformer.Model;
using TaskPerformer.Repo;

FileReader fileReader = new FileReader();
string fileName = "MOCK_DATA.xlsx";
string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "res", fileName);
if (File.Exists(filePath))
{
    var data = fileReader.Read(fileName);
}

//foreach (var single_data in data)
//{
//    Console.WriteLine($"Name: {single_data.CompanyName}, State: {single_data.State}");
//}

StateComplianceRepo complianceRepo = new StateComplianceRepo();
var stateCompliance = complianceRepo.GetStateCompliance();

foreach (var compliance in stateCompliance)
{
    Console.WriteLine($"State Name: {compliance.State}");
	foreach (var item in compliance.Compliances)
	{
        Console.WriteLine($"\tCompliance Name: {item.Name}");
    }
}