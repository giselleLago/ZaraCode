using System.Collections.Generic;

namespace ZaraCode.Models
{
    public class InvestmetResult
    {
        public IEnumerable<Stocks> StockList { get; set; }
        public decimal FinalCapital { get; set; }
        public decimal TotalInvestment { get; set; }
        public decimal TotalGain { get; set; }
    }
}
