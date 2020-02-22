using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZaraCode;

namespace ZaraCodeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetFinalCapital_test()
        {
            var listDailyStock = new List<DailyStock>();

            listDailyStock.Add(new DailyStock { DateTime = new DateTime(2001, 5, 23), OpenDay = 1 , CloseDay = 2});
            listDailyStock.Add(new DailyStock { DateTime = new DateTime(2001, 5, 24), OpenDay = 3, CloseDay = 4 });
            listDailyStock.Add(new DailyStock { DateTime = new DateTime(2001, 5, 25), OpenDay = 5, CloseDay = 6 });
            listDailyStock.Add(new DailyStock { DateTime = new DateTime(2001, 5, 26), OpenDay = 6, CloseDay = 6 });
            listDailyStock.Add(new DailyStock { DateTime = new DateTime(2001, 5, 27), OpenDay = 7, CloseDay = 8 });

            InvestmentSimulator investmentSimulator = new InvestmentSimulator();
            var result = investmentSimulator.GetFinalCapital(listDailyStock);
            var expected = 78.400f;
            Assert.AreEqual(expected, result);

        }

        
    }
}
