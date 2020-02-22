using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaraCode
{
    public class ExcelSource
    {
        public IEnumerable<DailyStock> ExtractData()
        {
            var dataList = new List<string[]>();
            var dailyList = new List<DailyStock>();
            string[] data;
           
            using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(@"C:\Users\holacons\source\repos\ZaraCode\stocks-ITX.xlsx")))
            {
                var selectSheet = excelPackage.Workbook.Worksheets.First();
                var totalRows = selectSheet.Dimension.End.Row;
                var totalColumns = selectSheet.Dimension.End.Column;

                for (int rowNum = 2; rowNum <= totalRows; rowNum++) 
                {
                    DailyStock dailyStock = new DailyStock();
                    var row = selectSheet.Cells[rowNum, 1, rowNum, totalColumns].Select(c => c.Value == null ? string.Empty : c.Value.ToString());
                    var line = row.ElementAt(0);
                    data = line.Split(';');

                    for (int i = 0; i < data.Length; i++)
                    {
                        CultureInfo myCultureInfo = new CultureInfo("es-US");
                        var a = data[i];
                        if (i == 0)
                        {
                            DateTime dTime = DateTime.Parse(a, myCultureInfo);
                            dailyStock.dateTime = dTime;
                        }
                        else if (i == 1)
                        {
                            dailyStock.OpenDay = Decimal.Parse(a, CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            dailyStock.CloseDay = Decimal.Parse(a, CultureInfo.InvariantCulture);
                        }
                    }
                    dailyList.Add(dailyStock);
                                
                }   
            }
            return dailyList;
        }

        
    }
}

