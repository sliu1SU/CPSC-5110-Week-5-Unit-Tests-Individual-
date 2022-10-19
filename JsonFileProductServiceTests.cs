using System.Linq;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product.AddRating
{
    public class JsonFileProductServiceTests
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region AddRating
        //[Test]
        //public void AddRating_InValid_....()
        //{
        //    // Arrange

        //    // Act
        //    //var result = TestHelper.ProductService.AddRating(null, 1);

        //    // Assert
        //    //Assert.AreEqual(false, result);
        //}

        // ....

        [Test]
        public void AddRating_InValid_Product_Null_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating(null, 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_InValid_Product_Empty_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("", 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_Valid_Product_Rating_5_Should_Return_True()
        {
            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();
            var countOriginal = data.Ratings.Length;

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 5);
            var dataNewList = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }

        [Test]
        public void AddRating_InValid_Product_InvalidID_Should_Return_False()
        {
            // assign

            // act
            bool result = TestHelper.ProductService.AddRating("sdasdasd", 2);

            // assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_InValid_Product_Rating_Low_Should_Return_False()
        {
            // assign

            // act
            ProductModel data = TestHelper.ProductService.GetAllData().First();
            bool result = TestHelper.ProductService.AddRating(data.Id, -8);

            // assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_InValid_Product_Rating_High_Should_Return_False()
        {
            // assign

            // act
            ProductModel data = TestHelper.ProductService.GetAllData().First();
            bool result = TestHelper.ProductService.AddRating(data.Id, 8);

            // assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_Valid_Product_Empty_Rating_Should_Return_True()
        {
            // assign

            // Get the First data item
            string testID = "jenlooper-light";
            ProductModel data = TestHelper.ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals(testID));
            int ratingLengthBefore = data.Ratings.Length;

            // act
            bool result = TestHelper.ProductService.AddRating(testID, 5);
            ProductModel dataNewList = TestHelper.ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals(testID));

            // assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(ratingLengthBefore + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }
        #endregion AddRating
    }
}