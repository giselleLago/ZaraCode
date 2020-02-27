using System.Collections.Generic;
using ZaraCode.Models;

namespace ZaraCode.Services
{
    public interface IInvestmentSimulator
    {
        InvestmetResult Calculate(IList<DailyStock> dataList);
    }
}
