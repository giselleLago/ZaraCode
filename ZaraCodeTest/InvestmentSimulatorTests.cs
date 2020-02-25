using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZaraCode;

namespace ZaraCodeTest
{
    [TestClass]
    public class InvestmentSimulatorTests
    {
        [TestMethod]
        public void GetFinalCapital_GivenASingleExplicitThursday()
        {
            var listDailyStock = new List<DailyStock>
            {
                new DailyStock { DateTime = new DateTime(2001, 5, 23), OpenDay = 1, CloseDay = 2 },
                new DailyStock { DateTime = new DateTime(2001, 5, 24), OpenDay = 3, CloseDay = 4 },
                new DailyStock { DateTime = new DateTime(2001, 5, 25), OpenDay = 5, CloseDay = 6 },
                new DailyStock { DateTime = new DateTime(2001, 5, 26), OpenDay = 6, CloseDay = 6 },
                new DailyStock { DateTime = new DateTime(2001, 5, 27), OpenDay = 7, CloseDay = 8 }
            };

            InvestmentSimulator investmentSimulator = new InvestmentSimulator();
            var result = investmentSimulator.GetFinalCapital(listDailyStock, 50);
            var expected = 78.433d;
            var list = new List<Income>();
            {
                new Income { LastDayMonth = new DateTime(2001, 5, 27), TotalIncome = 78.433};
            };
            Assert.AreEqual(expected, result.Item1);
            CollectionAssert.Equals(list, result);
        }

        [TestMethod]
        public void GetFinalCapital_GivenTwoExplicitThursdays()
        {
            var listDailyStock = new List<DailyStock>
            {
                new DailyStock { DateTime = new DateTime(2001, 5, 24), OpenDay = 3, CloseDay = 2 },
                new DailyStock { DateTime = new DateTime(2001, 5, 25), OpenDay = 2.5, CloseDay = 4 },
                new DailyStock { DateTime = new DateTime(2001, 5, 28), OpenDay = 3, CloseDay = 2 },
                new DailyStock { DateTime = new DateTime(2001, 6, 28), OpenDay = 1, CloseDay = 7 },
                new DailyStock { DateTime = new DateTime(2001, 6, 29), OpenDay = 2, CloseDay = 3 },
                new DailyStock { DateTime = new DateTime(2001, 6, 30), OpenDay = 1, CloseDay = 3 }
            };

            InvestmentSimulator investmentSimulator = new InvestmentSimulator();
            var result = investmentSimulator.GetFinalCapital(listDailyStock, 50);
            var expected = 132.258d;
            var list = new List<Income>();
            {
                new Income { LastDayMonth = new DateTime(2001, 5, 27), TotalIncome = 39.22 };
                new Income { LastDayMonth = new DateTime(2001, 6, 30), TotalIncome = 132.258 };
            };
            Assert.AreEqual(expected, result.Item1);
            CollectionAssert.Equals(list, result);
        }

        [TestMethod]
        public void GetFinalCapital_GivenTwoImplicitThursdays()
        {
            var listDailyStock = new List<DailyStock>
            {
                new DailyStock { DateTime = new DateTime(2001, 5, 23), OpenDay = 3, CloseDay = 2},
                new DailyStock { DateTime = new DateTime(2001, 5, 25), OpenDay = 2.5, CloseDay = 4},
                new DailyStock { DateTime = new DateTime(2001, 5, 28), OpenDay = 3, CloseDay = 2},
                new DailyStock { DateTime = new DateTime(2001, 6, 27), OpenDay = 1, CloseDay = 7},
                new DailyStock { DateTime = new DateTime(2001, 6, 29), OpenDay = 2, CloseDay = 3},
                new DailyStock { DateTime = new DateTime(2001, 6, 30), OpenDay = 1, CloseDay = 3}
            };

            InvestmentSimulator investmentSimulator = new InvestmentSimulator();
            var result = investmentSimulator.GetFinalCapital(listDailyStock, 50);
            var expected = 132.258d;
            var list = new List<Income>();
            {
                new Income { LastDayMonth = new DateTime(2001, 5, 27), TotalIncome = 39.22};
                new Income { LastDayMonth = new DateTime(2001, 6, 30), TotalIncome = 13};
            };
            Assert.AreEqual(expected, result.Item1);
            CollectionAssert.Equals(list, result);
        }

    }
}
