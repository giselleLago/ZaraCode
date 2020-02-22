using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaraCode
{
    class Program
    {
        static void Main(string[] args)
        {
            ExcelSource dataInfo = new ExcelSource();
            dataInfo.ExtractData();
            
            Console.ReadKey();
        }
    }
}
