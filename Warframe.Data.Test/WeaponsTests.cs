using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Warframe.Data.Test
{
    [TestClass]
    public class WeaponsTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dataAccess = 
                new WeaponsDataAccess(
                    TestConstants.BaseUrl, 
                    TestConstants.Index, 
                    TestConstants.Refresh);

            dataAccess.Load().Wait();
            var weapons = dataAccess.GetAllWeapons().Result;
            Assert.IsNotNull(weapons);
        }
    }
}
