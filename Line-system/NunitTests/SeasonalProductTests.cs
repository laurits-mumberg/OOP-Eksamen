using System;
using Line_system;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace NunitTests
{
    public class SeasonalProductTests
    {
        [TestCase(1, 1, true)]
        [TestCase(2, -1, false)]
        public void SeasonalProduct_IsActive_CorrectBool(int daysBeforeToday, int daysAfterToday, bool expected)
        {
            DateTime startDate = DateTime.Now.AddDays(-daysBeforeToday);
            DateTime endDate = DateTime.Now.AddDays(daysAfterToday);
            
            SeasonalProduct seasonalProduct = new SeasonalProduct(1,"test",10,false,false,startDate,endDate);
            Assert.AreEqual(seasonalProduct.IsActive, expected);
        }
    }
}