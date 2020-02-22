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
            InvestmentSimulator dataInfo = new InvestmentSimulator();
            dataInfo.GetFinalCapital();
            
            
            Console.ReadKey();
        }
    }
}
