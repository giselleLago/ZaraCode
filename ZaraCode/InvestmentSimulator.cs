using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaraCode
{
    public class InvestmentSimulator
    {
        public float GetFinalCapital(List<DailyStock> dataList)
        {
            var monthlyInvestment = 50 - 50 * 0.02f;
            var currentCapital = 0.0f;
            var cDay = 0.0f;
            var lastThursdayOfMonth = false;
            var init = false;
            for (int i = 0; i < dataList.Count; i++)
            {
                var dailyStock = dataList[i];
                var dailyFluctuation = (float)Math.Round((dailyStock.CloseDay - dailyStock.OpenDay) / dailyStock.OpenDay, 3);
                
                var dTime = dailyStock.DateTime;
                var firstDayOfNextMonth = new DateTime(dTime.Year, dTime.Month, 1).AddMonths(1);
                int vector = (((int)firstDayOfNextMonth.DayOfWeek + 1) % 7) + 2;
                var r = firstDayOfNextMonth.AddDays(-vector);
                if (init == true || dTime == r )
                {
                    if (lastThursdayOfMonth)
                    {
                        if (cDay != 0)
                        {
                            var fluctuationAfterMarket = (float)Math.Round((dailyStock.OpenDay - cDay) / cDay, 3);
                            currentCapital += (float)Math.Round(fluctuationAfterMarket * currentCapital + monthlyInvestment, 3);
                            currentCapital += (float)Math.Round(dailyFluctuation * currentCapital, 3);
                            lastThursdayOfMonth = false;
                            cDay = dailyStock.CloseDay;
                        }
                        else
                        {
                            if (currentCapital == 0)
                            {
                                currentCapital = monthlyInvestment;
                                currentCapital += (float)Math.Round(dailyFluctuation * currentCapital, 3);
                                lastThursdayOfMonth = false;
                                cDay = dailyStock.CloseDay;
                            }
                        } 
                    }
                    else if(init)
                    {
                        var fluctuationAfterMarket = (float)Math.Round((dailyStock.OpenDay - cDay) / cDay, 3);
                        currentCapital += (float)Math.Round(fluctuationAfterMarket * currentCapital, 3);
                        currentCapital += (float)Math.Round(dailyFluctuation * currentCapital, 3);
                        cDay = dailyStock.CloseDay; 
                    }

                    if (dTime == r)
                    {
                        lastThursdayOfMonth = true;
                    }
                    init = true;
                }
            }
            var finalCapital = (float)Math.Round(currentCapital, 3);
            return finalCapital;
        }
    }
}
