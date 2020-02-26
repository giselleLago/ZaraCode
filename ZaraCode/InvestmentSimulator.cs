using System;
using System.Collections.Generic;

namespace ZaraCode
{
    public class InvestmentSimulator
    {
        public const int Invvestment = 50;
        public const int Broker = Invvestment * 2 / 100;
        public const int RealInvestment = Invvestment - Broker;
        public DateTime GetLastThursday(DailyStock daily)
        {
            var lastDayOfMonth = new DateTime(daily.DateTime.Year, daily.DateTime.Month, DateTime.DaysInMonth(daily.DateTime.Year, daily.DateTime.Month));

            while (lastDayOfMonth.DayOfWeek != DayOfWeek.Thursday)
                lastDayOfMonth = lastDayOfMonth.AddDays(-1);

            return lastDayOfMonth;
        }

        private string GetKey(DateTime date) => $"{date.Month} - {date.Year}";

        public InvestmetResult GetFinalCapital(List<DailyStock> dataList)
        {
            var totalStock = 0m;
            var finalCapital = 0m;
            var dictionary = new Dictionary<string, bool>();
            var listStocks = new List<Stocks>();

            for (int i = 1; i < dataList.Count; i++)
            {
                var previous = dataList[i - 1];
                var current = dataList[i];
                var lastThursday = GetLastThursday(previous);
                var key = GetKey(previous.DateTime);

                if ((previous.DateTime >= lastThursday || current.DateTime > lastThursday) && !dictionary.ContainsKey(key))
                {
                    totalStock = Math.Round(totalStock + RealInvestment / current.OpenDay, 3);
                    dictionary.Add(key, true);
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
            var result = new InvestmetResult
            {
                StockList = listStocks,
                FinalCapital = finalCapital
            };

            return result;
        }
    }
}

