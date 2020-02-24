using System;
using System.Linq;

namespace ZaraCode
{
    class Program
    {
        static void Main(string[] args)
        {
            InvestmentSimulator dataInfo = new InvestmentSimulator();
            ExcelSource excelSource = new ExcelSource();
            var list = excelSource.ExtractData().ToList();
            var result = dataInfo.GetFinalCapital(list, 50);
            Console.WriteLine("Result value: {0:N3}", result);
            
            Console.ReadKey();
        }
    }
}
