using System;
using System.Diagnostics;
using ZaraCode.Services;

namespace ZaraCode
{
    static class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("Reading data source...");
            IInvestmentSimulator indexSimulator = new InvestmentSimulator();
            IDataSource dataSource = new ExcelSource();
            IExporter exporter = new ExcelExporter();
            var list = dataSource.ExtractData();
            Console.WriteLine("Calculating...");
            var incomeList = indexSimulator.Calculate(list);
            Console.WriteLine($"Final Capital: {incomeList.FinalCapital}");
            Console.WriteLine($"Total Investment: {incomeList.TotalInvestment}");
            Console.WriteLine($"Total Gain: {incomeList.TotalGain}");
            Console.WriteLine("Exporting data to Excel...");
            exporter.Export(incomeList.StockList, @"ZaraCode.xlsx");
            sw.Stop();
            Console.WriteLine("Time elapsed: {0}", sw.Elapsed.ToString("hh\\:mm\\:ss\\.fff"));
            Console.ReadKey();
        }
    }
}
