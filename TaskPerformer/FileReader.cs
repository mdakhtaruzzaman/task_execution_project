using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPerformer.Model;

namespace TaskPerformer
{
    internal class FileReader
    {
        public List<CompanyData> Read(string pathToFile)
        {
            List<CompanyData> dataList = new List<CompanyData>();

            using (var workbook = new XLWorkbook(pathToFile))
            {
                var worksheet = workbook.Worksheet(1); // Assuming the first worksheet
                int startRow = 2; // Assuming row 1 is the header, and data starts from row 2

                // Loop through the rows and read the data
                foreach (var row in worksheet.RowsUsed().Skip(startRow - 1))
                {
                    int id = int.Parse(row.Cell(1).Value.ToString());
                    var state = row.Cell(2).Value.ToString();
                    var companyName = row.Cell(3).Value.ToString();
                    int numberOfEmp = int.Parse(row.Cell(4).Value.ToString());
                    int maleEmp = int.Parse(row.Cell(5).Value.ToString());
                    int femaleEmp = int.Parse(row.Cell(6).Value.ToString());
                    int above50Age = int.Parse(row.Cell(7).Value.ToString());
                    // Create a new ExcelData object and add it to the list
                    if (!string.IsNullOrEmpty(state) && !string.IsNullOrEmpty(companyName))
                    {
                        // Create a new ExcelData object and add it to the list
                        CompanyData data = new CompanyData
                        {
                            Id = id,
                            State = state,
                            CompanyName = companyName,
                            NumberOfEmp = numberOfEmp,
                            MaleEmp = maleEmp,
                            FemaleEmp = femaleEmp,
                            Above50Age = above50Age,
                        };
                        dataList.Add(data);
                    }
                }
            }

            return dataList;
        }
    }
}
