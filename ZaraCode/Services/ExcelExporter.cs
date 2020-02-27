using Syncfusion.XlsIO;
using System.Collections.Generic;
using System.IO;
using ZaraCode.Models;

namespace ZaraCode.Services
{
    public class ExcelExporter : IExporter
    {
        public void Export(IEnumerable<Stocks> stocks, string fileName)
        {
            using (var excelEngine = new ExcelEngine())
            {
                var application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2013;
                var workbook = application.Workbooks.Create(1);
                var worksheet = workbook.Worksheets[0];
                
                worksheet.ImportData(stocks, 2, 1, false);

                worksheet["A1"].Text = "Date";
                worksheet["B1"].Text = "Income";

                worksheet.UsedRange.AutofitColumns();
                var excelStream = File.Create(Path.GetFullPath(fileName));
                workbook.SaveAs(excelStream);
            }
        }
    }
}
