﻿using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using ZaraCode.Models;

namespace ZaraCode.Services
{
    public class ExcelSource
    {
        public IEnumerable<DailyStock> ExtractData()
        {
            var dailyList = new List<DailyStock>();
            string[] data;
           
            using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(@"C:\Users\holacons\source\repos\ZaraCode\stocks-ITX.xlsx")))
            {
                var selectSheet = excelPackage.Workbook.Worksheets.First();
                var totalRows = selectSheet.Dimension.End.Row;
                var totalColumns = selectSheet.Dimension.End.Column;

                while (totalRows >= 2) 
                {
                    DailyStock dailyStock = new DailyStock();
                    var row = selectSheet.Cells[totalRows, 1, totalRows, totalColumns].Select(c => c.Value == null ? string.Empty : c.Value.ToString());
                    var line = row.ElementAt(0);
                    data = line.Split(';');

                    for (int i = 0; i < data.Length; i++)
                    {
                        CultureInfo myCultureInfo = new CultureInfo("es-US");
                        var a = data[i];
                        if (i == 0)
                        {
                            DateTime dTime = DateTime.Parse(a, myCultureInfo);
                            dailyStock.DateTime = dTime;
                        }
                        else if (i == 1)
                        {
                            dailyStock.CloseDay = decimal.Parse(a, CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            dailyStock.OpenDay = decimal.Parse(a, CultureInfo.InvariantCulture);
                        }
                    }
                    dailyList.Add(dailyStock);
                    totalRows--;
                }   
            }
            return dailyList;
        }

        
    }
}
