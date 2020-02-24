using System;
using System.Diagnostics;
using System.Linq;

namespace ZaraCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("Running Zara Tech Code...");
            InvestmentSimulator indexSimulator = new InvestmentSimulator();
            ExcelSource excelSource = new ExcelSource();
            ExcelGenerator excelGenerator = new ExcelGenerator();
            var list = excelSource.ExtractData().ToList();
            var resultFinalCapital = indexSimulator.GetFinalCapital(list, 50);
            Console.WriteLine("Exporting data to Excel...");
            var incomeList = resultFinalCapital.Item2;
            excelGenerator.ExportList(incomeList);
            Console.WriteLine("Result value: {0:N3}", resultFinalCapital.Item1);
            sw.Stop();
            Console.WriteLine("Time elapsed: {0}", sw.Elapsed.ToString("hh\\:mm\\:ss\\.fff"));


            Console.ReadKey();
        }
    }
}
