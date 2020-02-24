using Syncfusion.XlsIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaraCode;

namespace ZaraCode
{
    public class ExcelGenerator
    {

        public void ExportList(List<Income> income)
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2013;
                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet worksheet = workbook.Worksheets[0];
 
                List<Income> incomes = income;
                worksheet.ImportData(incomes, 2, 1, false);

                IStyle tableHeader = workbook.Styles.Add("TableHeaderStyle");
                tableHeader.Font.Color = ExcelKnownColors.Dark_green;
                tableHeader.Font.Bold = true;
                tableHeader.Font.Size = 11;
                tableHeader.Font.FontName = "Calibri";
                tableHeader.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                tableHeader.VerticalAlignment = ExcelVAlign.VAlignCenter;
                tableHeader.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
                tableHeader.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
                tableHeader.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Thin;
                tableHeader.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;

                worksheet["A1"].Text = "Date";
                worksheet["A1"].CellStyle = tableHeader;
                worksheet["B1"].Text = "Income";
                worksheet["B1"].CellStyle = tableHeader;
               

                worksheet.UsedRange.AutofitColumns();
                Stream excelStream = File.Create(Path.GetFullPath(@"ZaraCode.xlsx"));
                workbook.SaveAs(excelStream);
                excelStream.Dispose();
            }
        }
        
    }
}
