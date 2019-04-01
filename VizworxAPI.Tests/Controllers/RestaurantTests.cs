using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VizworxAPI.Models;
using VizworxAPI.Services;

namespace VizworxAPI.Tests.Controllers
{
    [TestClass]
    public class RestaurantTests
    {
        /// <summary>
        /// When restaurants are placed in the list, they should be sorted by highest to lowest rating.
        /// </summary>
        [TestMethod]
        public void TestSortingByRating()
        {
            // Create repositories.
            RestaurantRepository rc = new RestaurantRepository();
            List<Restaurant> restaurants = new List<Restaurant>();

            // Create restaurants.
            Restaurant r1 = new Restaurant
            {
                name = "A",
                rating = 2,
                numberOfMeals = 40,
                meals = new Dictionary<string, int> { { "vegetarian", 4 } }
            };

            r1.meals["normal"] = HelperFunctions.GetNumberOfNormalMeals(r1.numberOfMeals, r1.meals);

            restaurants = rc.AddByRatingToList(restaurants, r1);

            Restaurant r2 = new Restaurant
            {
                name = "B",
                rating = 5,
                numberOfMeals = 100,
                meals = new Dictionary<string, int> { { "vegetarian", 20 }, { "glutenFree", 20 } }
            };

            r2.meals["normal"] = HelperFunctions.GetNumberOfNormalMeals(r2.numberOfMeals, r2.meals);

            restaurants = rc.AddByRatingToList(restaurants, r2);

            Restaurant r3 = new Restaurant
            {
                name = "C",
                rating = 3,
                numberOfMeals = 100,
                meals = new Dictionary<string, int> { { "vegetarian", 20 }, { "glutenFree", 20 } }
            };

            r3.meals["normal"] = HelperFunctions.GetNumberOfNormalMeals(r3.numberOfMeals, r3.meals);

            restaurants = rc.AddByRatingToList(restaurants, r3);

            Restaurant r4 = new Restaurant
            {
                name = "D",
                rating = 3,
                numberOfMeals = 100,
                meals = new Dictionary<string, int> { { "vegetarian", 20 }, { "glutenFree", 20 } }
            };

            r3.meals["normal"] = HelperFunctions.GetNumberOfNormalMeals(r4.numberOfMeals, r4.meals);

            restaurants = rc.AddByRatingToList(restaurants, r4);

            // Check if they are ordered correctly.
            Assert.AreEqual("B", restaurants[0].name);
            Assert.AreEqual("C", restaurants[1].name);
            Assert.AreEqual("D", restaurants[2].name);
            Assert.AreEqual("A", restaurants[3].name);
        }
    }
}
