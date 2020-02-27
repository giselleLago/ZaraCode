using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using ZaraCode.Models;

namespace ZaraCode.Services
{
    public class ExcelSource : IDataSource
    {
        public IList<DailyStock> ExtractData()
        {
            var dailyList = new List<DailyStock>();
           
            using (var excelPackage = new ExcelPackage(new FileInfo(@"Data\stocks-ITX.xlsx")))
            {
                var selectSheet = excelPackage.Workbook.Worksheets.First();
                var totalRows = selectSheet.Dimension.End.Row;
                var totalColumns = selectSheet.Dimension.End.Column;
                var cultureInfo = new CultureInfo("es-US");

                while (totalRows >= 2) 
                {
                    var row = selectSheet.Cells[totalRows, 1, totalRows, totalColumns].Select(c => c.Value == null ? string.Empty : c.Value.ToString());
                    var line = row.ElementAt(0);
                    var data = line.Split(';');
                    var dailyStock = new DailyStock
                    {
                        DateTime = DateTime.Parse(data[0], cultureInfo),
                        CloseDay = decimal.Parse(data[1], CultureInfo.InvariantCulture),
                        OpenDay = decimal.Parse(data[2], CultureInfo.InvariantCulture)
                    };

                    dailyList.Add(dailyStock);
                    totalRows--;
                }   
            }
            return dailyList;
        }  
    }
}

