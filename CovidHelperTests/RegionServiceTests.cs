using CovidHelper.Models;
using CovidHelper.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CovidHelperTests
{
    [TestClass]
    public class RegionServiceTests
    {
        [TestMethod]
        public void Following_the_normal_process_the_list_should_have_10_items()
        {
            //Arrange
            var regionService = new RegionService();
            var expect = 10;

            //Act
            var list = Task.Run(async () =>
            {
                return await regionService.GetAll();
            }).GetAwaiter().GetResult();
            var result = list.Count;
            //Assert
            Assert.AreEqual(expect,result);
        }

        [TestMethod]
        public void Following_the_normal_process_the_list_should_have_10_items_by_US_province()
        {
            //Arrange
            var regionService = new RegionService();
            var expect = 10;

            //Act

            var list = Task.Run(async () =>
            {
                return await regionService.GetAllByProvince("US", "USA");
            }).GetAwaiter().GetResult(); 
            var result = list.Count;
            //Assert
            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void Should_have_all_the_same_region_when_you_get_by_provinces()
        {
            //Arrange
            var regionService = new RegionService();
           
            //Act

            var list = Task.Run(async () =>
            {
                return await regionService.GetAllByProvince("US", "USA");
            }).GetAwaiter().GetResult();
            var aleatoryCountry1 = list[2].Iso;
            var aleatoryCountry2 = list[9].Iso;
            //Assert
            Assert.AreEqual(aleatoryCountry1, aleatoryCountry2);
        }

        [TestMethod]
        public void The_first_should_have_more_cases_than_the_others_when_you_get_by_provinces()
        {
            //Arrange
            var regionService = new RegionService();

            //Act

            var list = Task.Run(async () =>
            {
                return await regionService.GetAllByProvince("US", "USA");
            }).GetAwaiter().GetResult();
            var firstProvince = list[0].Confirmed;
            var secondProvince = list[1].Confirmed;
            //Assert
            Assert.IsTrue(firstProvince > secondProvince);
        }

        [TestMethod]
        public void The_first_should_have_more_cases_than_the_others()
        {
            //Arrange
            var regionService = new RegionService();

            //Act

            var list = Task.Run(async () =>
            {
                return await regionService.GetAll();
            }).GetAwaiter().GetResult();
            var firstCountry = list[0].Confirmed;
            var secondCountry = list[1].Confirmed;
            var lastCountry = list[9].Confirmed;

            //Assert
            Assert.IsTrue(firstCountry > secondCountry && secondCountry>lastCountry);
        }

        [TestMethod]
        public void Should_return_the_data_of_the_regions()
        {
            //Arrange
            var regionService = new RegionService();
        
            //Act

            var list = Task.Run(async () =>
            {
                return await regionService.GetAllRegions();
            }).GetAwaiter().GetResult();
            var result = list.Data;
            
            //Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void Should_return_the_data_of_the_regions_with_its_detail()
        {
            //Arrange
            var regionService = new RegionService();

            //Act

            var list = Task.Run(async () =>
            {
                return await regionService.GetAll();
            }).GetAwaiter().GetResult();
            var result = list;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Should_return_the_data_of_the_provinces_of_US()
        {
            //Arrange
            var regionService = new RegionService();

            //Act

            var list = Task.Run(async () =>
            {
                return await regionService.GetAllByProvince("US", "USA"); 
            }).GetAwaiter().GetResult();
            var result = list;

            //Assert
            Assert.IsNotNull(result);
        }

        //[TestMethod]
        //public void Following_the_normal_process_the_list_should_have_10_items()
        //{

        //}

        //[TestMethod]
        //public void Following_the_normal_process_the_list_should_have_10_items()
        //{

        //}


    }
}
