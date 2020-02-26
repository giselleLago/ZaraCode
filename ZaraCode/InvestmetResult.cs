using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaraCode
{
    public class InvestmetResult
    {
        public IEnumerable<Stocks> StockList { get; set; }
        public decimal FinalCapital { get; set; }
    }
}
