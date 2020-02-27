using Syncfusion.XlsIO;
using System.Collections.Generic;
using System.IO;
using ZaraCode.Models;

namespace ZaraCode.Services
{
    public class ExcelExporter : IExporter
    {
        public void Export(InvestmetResult result, string fileName)
        {
            using (var excelEngine = new ExcelEngine())
            {
                var application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2013;
                var workbook = application.Workbooks.Create(1);
                var worksheet = workbook.Worksheets[0];
                var resultList = new List<object>
                {
                    new { value = result.TotalInvestment },
                    new { value = result.TotalGain },
                    new { value = result.FinalCapital }
                };

                worksheet.ImportData(result.StockList, 2, 1, false);
                worksheet.ImportData(resultList, 1, 5, false);

                worksheet["A1"].Text = "Date";
                worksheet["B1"].Text = "Stocks";
                worksheet["D1"].Text = "Total Investment";
                worksheet["D2"].Text = "Total Gain";
                worksheet["D3"].Text = "Final Capital";

                worksheet.UsedRange.AutofitColumns();
                using (var excelStream = File.Create(Path.GetFullPath(fileName)))
                {
                    workbook.SaveAs(excelStream);
                } 
            }
        }
    }
}
