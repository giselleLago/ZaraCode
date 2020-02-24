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

        public float GetFinalCapital(List<DailyStock> dataList, float monthlyInvestment)
        {
            var realInvestment = monthlyInvestment - monthlyInvestment * 0.02f;
            var currentCapital = 0f;
            var cDay = 0f;
            var init = false;
            var month = 0;
            var lastDailyStock = new DateTime();
            for (int i = 0; i < dataList.Count; i++)
            {
                var dailyStock = dataList[i];
                var dailyFluctuation = (float)Math.Round((dailyStock.CloseDay - dailyStock.OpenDay) / dailyStock.OpenDay, 3); 
                var lastThursday = GetLastThursday(dailyStock);
                

                if (dailyStock.DateTime > lastThursday && lastDailyStock <= lastThursday && month != dailyStock.DateTime.Month)
                {
                    if (currentCapital == 0)
                    {
                        currentCapital = realInvestment;
                        currentCapital += (float)Math.Round(dailyFluctuation * currentCapital, 3);
                        cDay = dailyStock.CloseDay;
                        month = dailyStock.DateTime.Month;
                        init = true;
                    }
                    else
                    {
                        var fluctuationAfterMarket = (float)Math.Round((dailyStock.OpenDay - cDay) / cDay, 3);
                        currentCapital += (float)Math.Round(fluctuationAfterMarket * currentCapital + realInvestment, 3);
                        currentCapital += (float)Math.Round(dailyFluctuation * currentCapital, 3);
                        cDay = dailyStock.CloseDay;
                    }
                    
                }
                else if (init)
                {
                    var fluctuationAfterMarket = (float)Math.Round((dailyStock.OpenDay - cDay) / cDay, 3);
                    currentCapital += (float)Math.Round(fluctuationAfterMarket * currentCapital, 3);
                    currentCapital += (float)Math.Round(dailyFluctuation * currentCapital, 3);
                    cDay = dailyStock.CloseDay;
                }

                lastDailyStock = dailyStock.DateTime;
            }
            var finalCapital = (float)Math.Round(currentCapital, 3);
            return finalCapital;
        }
    }
}
