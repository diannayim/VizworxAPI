using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VizworxAPI.Models;
using VizworxAPI.Services;

namespace VizworxAPI.Tests
{
    [TestClass]
    public class MealTests
    {
        /// <summary>
        /// Uses example given in the coding challenge.
        /// </summary>
        [TestMethod]
        public void TestGivenExample()
        {
            // Setup repositories as needed.
            RestaurantRepository rc = new RestaurantRepository();
            MealRepository mr = new MealRepository();

            // Create a list for the restaurants to be placed in.
            List<Restaurant> restaurants = new List<Restaurant>();

            // Create a team of 50 members who need 5 vegetarian meals and 7 gluten free.
            Team t = new Team
            {
                numberOfMembers = 50,
                meals = new Dictionary<string, int> { { "vegetarian", 5 }, { "glutenFree", 7 } }
            };

            // Insert in normal meals for the team.
            t.meals["normal"] = HelperFunctions.GetNumberOfNormalMeals(t.numberOfMembers, t.meals);

            // Create a restaurant with a rating of 5 with the name of A that has 40 meals, 4 of which are vegetarian.
            Restaurant r1 = new Restaurant
            {
                name = "A",
                rating = 5,
                numberOfMeals = 40,
                meals = new Dictionary<string, int> { { "vegetarian", 4 } }
            };

            // Insert in normal meals for restaurant A.
            r1.meals["normal"] = HelperFunctions.GetNumberOfNormalMeals(r1.numberOfMeals, r1.meals);

            // Place restaurant in list to be ordered by rating.
            restaurants = rc.AddByRatingToList(restaurants, r1);

            // Create a restaurant with a rating of 3 with the name of B that has 100 meals, 20 of which are vegetarian and 20 are gluten free.
            Restaurant r2 = new Restaurant
            {
                name = "B",
                rating = 3,
                numberOfMeals = 100,
                meals = new Dictionary<string, int> { { "vegetarian", 20 }, { "glutenFree", 20 } }
            };

            // Insert in normal meals for restaurant B.
            r2.meals["normal"] = HelperFunctions.GetNumberOfNormalMeals(r2.numberOfMeals, r2.meals);

            // Place restaurant in a list to be ordered by rating.
            restaurants = rc.AddByRatingToList(restaurants, r2);

            // Get the meal order with team and restaurants.
            Dictionary<string, Dictionary<string, int>> mealOrder = mr.GetMealOrder(t, restaurants);

            // Check if results are correct.
            Assert.AreEqual(4, mealOrder["A"]["vegetarian"]);
            Assert.AreEqual(36, mealOrder["A"]["normal"]);

            Assert.AreEqual(1, mealOrder["B"]["vegetarian"]);
            Assert.AreEqual(7, mealOrder["B"]["glutenFree"]);
            Assert.AreEqual(2, mealOrder["B"]["normal"]);
        }

        /// <summary>
        /// Test when restaurants have meals that team doesn't need.
        /// </summary>
        [TestMethod]
        public void TestMealsNotRequired()
        {
            // Setup repositories as needed.
            RestaurantRepository rc = new RestaurantRepository();
            MealRepository mr = new MealRepository();

            // Create a list for the restaurants to be placed in.
            List<Restaurant> restaurants = new List<Restaurant>();

            // Create a team of 50 members who need 5 vegetarian meals and 7 gluten free.
            Team t = new Team
            {
                numberOfMembers = 50,
                meals = new Dictionary<string, int> { { "vegetarian", 5 }, { "glutenFree", 7 } }
            };

            // Insert in normal meals for the team.
            t.meals["normal"] = HelperFunctions.GetNumberOfNormalMeals(t.numberOfMembers, t.meals);

            // Create a restaurant with a rating of 5 with the name of A that has 60 meals, 4 of which are vegetarian and 20 are fish free.
            Restaurant r1 = new Restaurant
            {
                name = "A",
                rating = 5,
                numberOfMeals = 60,
                meals = new Dictionary<string, int> { { "vegetarian", 4 }, { "fishFree", 20 } }
            };

            // Insert in normal meals for restaurant A.
            r1.meals["normal"] = HelperFunctions.GetNumberOfNormalMeals(r1.numberOfMeals, r1.meals);

            // Place restaurant in list to be ordered by rating.
            restaurants = rc.AddByRatingToList(restaurants, r1);

            // Create a restaurant with a rating of 3 with the name of B that has 100 meals, 20 of which are vegetarian and 20 are gluten free.
            Restaurant r2 = new Restaurant
            {
                name = "B",
                rating = 3,
                numberOfMeals = 100,
                meals = new Dictionary<string, int> { { "vegetarian", 20 }, { "glutenFree", 20 } }
            };

            // Insert in normal meals for restaurant B.
            r2.meals["normal"] = HelperFunctions.GetNumberOfNormalMeals(r2.numberOfMeals, r2.meals);

            // Place restaurant in a list to be ordered by rating.
            restaurants = rc.AddByRatingToList(restaurants, r2);

            // Get the meal order with team and restaurants.
            Dictionary<string, Dictionary<string, int>> mealOrder = mr.GetMealOrder(t, restaurants);

            // Check if results are correct.
            Assert.AreEqual(4, mealOrder["A"]["vegetarian"]);
            Assert.AreEqual(36, mealOrder["A"]["normal"]);

            Assert.AreEqual(1, mealOrder["B"]["vegetarian"]);
            Assert.AreEqual(7, mealOrder["B"]["glutenFree"]);
            Assert.AreEqual(2, mealOrder["B"]["normal"]);
        }
    }
}
