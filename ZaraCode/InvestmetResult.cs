using System.Collections.Generic;

namespace ZaraCode
{
    public class InvestmetResult
    {
        public IEnumerable<Stocks> StockList { get; set; }
        public decimal FinalCapital { get; set; }
    }
}
