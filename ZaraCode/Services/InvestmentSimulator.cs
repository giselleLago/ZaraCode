using System;
using System.Collections.Generic;
using ZaraCode.Models;

namespace ZaraCode.Services
{
    public class InvestmentSimulator : IInvestmentSimulator
    {
        private const int Invvestment = 50;
        private const int Broker = Invvestment * 2 / 100;
        private const int RealInvestment = Invvestment - Broker;

        public InvestmetResult Calculate(IList<DailyStock> dataList)
        {
            var totalStock = 0m;
            var finalCapital = 0m;
            var totalInvestment = 0m;
            var dictionary = new Dictionary<string, bool>();
            var listStocks = new List<Stocks>();

            for (int i = 1; i < dataList.Count; i++)
            {
                var previous = dataList[i - 1];
                var current = dataList[i];
                var lastThursday = GetLastThursday(previous);
                var key = GetKey(previous.DateTime);
                var mustInvest = (previous.DateTime >= lastThursday || current.DateTime > lastThursday) && !dictionary.ContainsKey(key);

                if (mustInvest)
                {
                    totalStock = Math.Round(totalStock + RealInvestment / current.OpenDay, 3);
                    dictionary.Add(key, true);
                    totalInvestment += RealInvestment;
                    listStocks.Add(new Stocks
                    {
                        LastDayMonth = current.DateTime,
                        TotalStocks = totalStock
                    });
                }

                if (i == dataList.Count - 1)
                {
                    finalCapital = Math.Round(totalStock * current.CloseDay, 3);
                }
            }

            return new InvestmetResult
            {
                StockList = listStocks,
                FinalCapital = finalCapital,
                TotalInvestment = totalInvestment,
                TotalGain = finalCapital - totalInvestment
            };
        }

        private DateTime GetLastThursday(DailyStock daily)
        {
            var lastDayOfMonth = new DateTime(daily.DateTime.Year, daily.DateTime.Month, DateTime.DaysInMonth(daily.DateTime.Year, daily.DateTime.Month));

            while (lastDayOfMonth.DayOfWeek != DayOfWeek.Thursday)
                lastDayOfMonth = lastDayOfMonth.AddDays(-1);

            return lastDayOfMonth;
        }

        private string GetKey(DateTime date) => $"{date.Month} - {date.Year}";
    }
}

