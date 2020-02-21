using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaraCode
{
    public class DataInfo
    {
        public void ExtractData()
        {
            var dataBuild = new StringBuilder();
            using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(@"C:\Users\holacons\source\repos\ZaraCode\stocks-ITX.xlsx")))
            {
                var selectSheet = excelPackage.Workbook.Worksheets.First();
                var totalRows = selectSheet.Dimension.End.Row;
                var totalColumns = selectSheet.Dimension.End.Column;

                for (int rowNum = 1; rowNum <= totalRows; rowNum++) 
                {
                    var row = selectSheet.Cells[rowNum, 1, rowNum, totalColumns].Select(c => c.Value == null ? string.Empty : c.Value.ToString());
                    dataBuild.AppendLine(string.Join(",", row));
    
                }
            }
            Console.WriteLine(dataBuild);
        }
    }
}

