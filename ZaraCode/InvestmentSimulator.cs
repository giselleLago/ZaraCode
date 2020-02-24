using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaraCode
{
    public class InvestmentSimulator
    {
        public DateTime GetLastThursday(DailyStock daily)
        {
            var firstDayOfNextMonth = new DateTime(daily.DateTime.Year, daily.DateTime.Month, 1).AddMonths(1);
            int vector = (((int)firstDayOfNextMonth.DayOfWeek + 1) % 7) + 2;
            var lastThursday = firstDayOfNextMonth.AddDays(-vector);
            
            return lastThursday;
        }

        public (double, List<Income>) GetFinalCapital(List<DailyStock> dataList, double monthlyInvestment)
        {
            var realInvestment = monthlyInvestment - monthlyInvestment * 0.02;
            var currentCapital = 0d;
            var cDay = 0d;
            var init = false;
            var month = 0;
            var incomePerMonth = new List<Income>();
            var lastDailyStock = new DateTime();
            for (int i = 0; i < dataList.Count; i++)
            {
                var dailyStock = dataList[i];
                var dailyFluctuation = Math.Round((dailyStock.CloseDay - dailyStock.OpenDay) / dailyStock.OpenDay, 3); 
                var lastThursday = GetLastThursday(dailyStock);

                if (dailyStock.DateTime.Month != lastDailyStock.Month && currentCapital != 0)
                {
                    incomePerMonth.Add(new Income 
                    { 
                        LastDayMonth = lastDailyStock, 
                        TotalIncome = Math.Round(currentCapital, 3)
                    });
                    
                }

                if (dailyStock.DateTime > lastThursday && lastDailyStock <= lastThursday && month != dailyStock.DateTime.Month)
                {
                    if (currentCapital == 0)
                    {
                        currentCapital = realInvestment;
                        currentCapital += Math.Round(dailyFluctuation * currentCapital, 3);
                        cDay = dailyStock.CloseDay;
                        month = dailyStock.DateTime.Month;
                        init = true;
                    }
                    else
                    {
                        var fluctuationAfterMarket = Math.Round((dailyStock.OpenDay - cDay) / cDay, 3);
                        currentCapital += Math.Round(fluctuationAfterMarket * currentCapital + realInvestment, 3);
                        currentCapital += Math.Round(dailyFluctuation * currentCapital, 3);
                        cDay = dailyStock.CloseDay;
                    }
                    
                }
                else if (init)
                {
                    var fluctuationAfterMarket = Math.Round((dailyStock.OpenDay - cDay) / cDay, 3);
                    currentCapital += Math.Round(fluctuationAfterMarket * currentCapital, 3);
                    currentCapital += Math.Round(dailyFluctuation * currentCapital, 3);
                    cDay = dailyStock.CloseDay;
                }
                if (i == dataList.Count - 1)
                {
                    incomePerMonth.Add(new Income
                    {
                        LastDayMonth = dailyStock.DateTime,
                        TotalIncome = Math.Round(currentCapital, 3)
                    });
                }
                lastDailyStock = dailyStock.DateTime;
            }
            var finalCapital = Math.Round(currentCapital, 3);
            var incomeList = incomePerMonth;
            return (finalCapital, incomeList);
        }
    }
}
