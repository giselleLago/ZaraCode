using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaraCode
{
    public class InvestmentSimulator
    {
        //last thursday every month
        //invierte el siguiente dia que se cotiza 50 - 2%(broker) al precio de apertura
        //Calcular cual será el capital final obtenido, si realiza la venta total de sus
        //acciones el día 28-dic-2017 al valor del cierre de la cotización.
        // el primer dia no hay fluctuationAfterMarket
        //el for comienza despues del primer cobro, no donde comienza la lista.
        
        public float GetFinalCapital()
        {
            ExcelSource dataInfo = new ExcelSource();
            var dataList = dataInfo.ExtractData().ToList();
            var monthlyInvestment = 50 - 50 * 0.02f;
            var currentCapital = 0.0f;
            var cDay = 0.0f;
            var lastThursdayOfMonth = false;
            for (int i = 0; i < dataList.Count; i++)
            { 
                var dailyStock = dataList[i]; 
                var dailyFluctuation = (float)Math.Round((dailyStock.CloseDay - dailyStock.OpenDay) / 100, 3);
                if (lastThursdayOfMonth)
                {
                    if (cDay != 0)
                    {
                        var fluctuationAfterMarket = (float)Math.Round((cDay - dailyStock.OpenDay) / 100, 3);
                        currentCapital += (float)Math.Round(dailyFluctuation + fluctuationAfterMarket + monthlyInvestment, 3);
                        lastThursdayOfMonth = false;
                    }
                    else
                    {
                        currentCapital += (float)Math.Round(dailyFluctuation + monthlyInvestment, 3);
                        lastThursdayOfMonth = false;
                    }
                    cDay = dailyStock.CloseDay;
                }
                else
                {
                    if (cDay != 0)
                    {
                        var fluctuationAfterMarket = (float)Math.Round((cDay - dailyStock.OpenDay) / 100, 3);
                        currentCapital += (float)Math.Round(dailyFluctuation + fluctuationAfterMarket, 3);
                    }
                    else
                    {
                        currentCapital += (float)Math.Round(dailyFluctuation, 3);
                    }
                    cDay = dailyStock.CloseDay;
                }
                var dTime = dailyStock.DateTime; 
                var firstDayOfNextMonth = new DateTime(dTime.Year, dTime.Month, 1).AddMonths(1);
                int vector = (((int)firstDayOfNextMonth.DayOfWeek + 1) % 7 )+ 2;
                var r = firstDayOfNextMonth.AddDays(-vector);
                
                if (dTime  == r )
                {
                    lastThursdayOfMonth = true;
                }
                
            }
            var finalCapital = currentCapital;
            return finalCapital;
        }
    }
}
