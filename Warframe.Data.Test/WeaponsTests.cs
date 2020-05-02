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
                new WeaponDataAccess(
                    TestConstants.BaseUrl, 
                    TestConstants.Index, 
                    TestConstants.Refresh);
            dataAccess.Load();
            var weapons = dataAccess.GetAllWeapons();
            Assert.IsNotNull(weapons);
        }
    }
}
