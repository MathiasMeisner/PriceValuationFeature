using System;
using Xunit;
using PriceValuationFeature.Managers;
using System.Collections.Generic;
using PriceValuationFeature.Models;

namespace PriceValuationFeatureTests
{
    public class ManagerTests
    {
        private readonly PriceValuationFeatureManager _manager = new PriceValuationFeatureManager();

        [Fact]
        public void GetAllTest_ShouldPass()
        {
            List<Home> homes = _manager.GetAll();

            Assert.Equal(6, homes.Count);
        }

        [Fact]
        public void GetByIdTest()
        {
            Home home = _manager.GetById(1);

            Assert.Equal(1, home.Id);
        }

        [Fact]
        public void TotalHomesForSaleTest()
        {
            Assert.Equal(1, _manager.TotalHomesForSaleInMunicipality(1));
        }

        [Fact]
        public void AvgKvmPriceTest()
        {
            // ARRANGE - define a variable showing the expected results with decimals
            double d = 48888.8888;

            // ACT - use math round to remove decimals
            double dc = Math.Round((double)d, 0);

            // ASSERT - takes the new variable and compares it to the method outcome
            Assert.Equal(dc, _manager.AvgKvmPriceInMunicipality(1));
        }

        [Fact]
        public void AvgKvmPriceTest2()
        {
            double d = 20415.4589;
            double dc = Math.Round((double)d, 0);
            Assert.Equal(dc, _manager.AvgKvmPriceInMunicipality2());
        }

        [Fact]
        public void AvgDaysForSaleTest()
        {
            Assert.Equal(93.5, _manager.AvgDaysForSaleInMunicipality());
        }

        [Fact]
        public void SortTest()
        {
            List<Home> sortPrice = _manager.GetAll(sortBy: "price");
            Assert.Equal(6000000, sortPrice[0].Price);

            List<Home> sortKvm = _manager.GetAll(sortBy: "kvm");
            Assert.Equal(115, sortKvm[2].Kvm);

            List<Home> sortDaysForSale = _manager.GetAll(sortBy: "daysforsale");
            Assert.Equal(180, sortDaysForSale[1].DaysForSale);
        }
    }
}
