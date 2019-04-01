using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VizworxAPI.Models;

namespace VizworxAPI.Services
{
    /// <summary>
    /// Class which holds the logic for Restaurants.
    /// </summary>
    public class RestaurantRepository
    {
        /// <summary>
        /// Cache key needed for data storage within HTTP Context.
        /// </summary>
        private const string CacheKey = "Restaurant";

        /// <summary>
        /// Creates a restaurant repository and sets up an empty list of restaurants.
        /// </summary>
        public RestaurantRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    ctx.Cache[CacheKey] = new List<Restaurant>();
                }
            }
        }

        /// <summary>
        /// Gets list of restaurants from HTTP Context.
        /// </summary>
        /// <returns>List of Restaurants</returns>
        public List<Restaurant> GetRestaurants()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (List<Restaurant>)ctx.Cache[CacheKey];
            }

            return new List<Restaurant>();
        }

        /// <summary>
        /// Adds a restaurant to the list in the order of rating.
        /// </summary>
        /// <param name="restaurant">Restaurant to be added.</param>
        public void AddRestaurant(Restaurant restaurant)
        {
            var ctx = HttpContext.Current;
            restaurant.meals["normal"] = HelperFunctions.GetNumberOfNormalMeals(restaurant.numberOfMeals, restaurant.meals);

            if (ctx != null)
            {
                List<Restaurant> list = (List<Restaurant>)ctx.Cache[CacheKey];
                ctx.Cache[CacheKey] = AddByRatingToList(list, restaurant);
            }
        }

        /// <summary>
        /// Adds restaurant to list and sorts by decending rating value.
        /// </summary>
        /// <param name="list">List of retaurant.s</param>
        /// <param name="restaurant">Restaurant to add.</param>
        /// <returns>New sorted list of restaurants with new restaurant added.</returns>
        public List<Restaurant> AddByRatingToList(List<Restaurant> list, Restaurant restaurant)
        {
            list.Add(restaurant);
            list = (from s in list orderby s.rating descending select s).ToList();

            return list;
        }
    }
}