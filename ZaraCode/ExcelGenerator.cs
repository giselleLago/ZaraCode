using Syncfusion.XlsIO;
using System.Collections.Generic;
using System.IO;

namespace ZaraCode
{
    public class ExcelGenerator
    {

        public void ExportList(IEnumerable<Stocks> income)
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2013;
                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet worksheet = workbook.Worksheets[0];
 
                IEnumerable<Stocks> incomes = income;
                worksheet.ImportData(incomes, 2, 1, false);

                worksheet["A1"].Text = "Date";
                worksheet["B1"].Text = "Income";
 
                worksheet.UsedRange.AutofitColumns();
                Stream excelStream = File.Create(Path.GetFullPath(@"ZaraCode.xlsx"));
                workbook.SaveAs(excelStream);
            }
        }
        
    }
}
