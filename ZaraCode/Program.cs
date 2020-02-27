using System;
using System.Diagnostics;
using ZaraCode.Services;

namespace ZaraCode
{
    static class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            log.Info("Reading data source...");
            IInvestmentSimulator indexSimulator = new InvestmentSimulator();
            IDataSource dataSource = new ExcelSource();
            IExporter exporter = new ExcelExporter();
            var list = dataSource.ExtractData();
            log.Info("Calculating...");
            var incomeList = indexSimulator.Calculate(list);
            log.Info($"Final Capital: {incomeList.FinalCapital}");
            log.Info($"Total Investment: {incomeList.TotalInvestment}");
            log.Info($"Total Gain: {incomeList.TotalGain}");
            log.Info("Exporting data to Excel...");
            exporter.Export(incomeList, @"ZaraCode.xlsx");
            sw.Stop();
            Console.WriteLine("Time elapsed: {0}", sw.Elapsed.ToString("hh\\:mm\\:ss\\.fff"));
            Console.ReadKey();
        }
    }
}
