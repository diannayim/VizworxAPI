using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VizworxAPI.Models;

namespace VizworxAPI.Services
{
    public class RestaurantRepository
    {
        private const string CacheKey = "Restaurant";

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

        public List<Restaurant> GetRestaurants()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (List<Restaurant>)ctx.Cache[CacheKey];
            }

            return new List<Restaurant>();
        }

        public bool AddRestaurant(Restaurant restaurant)
        {
            var ctx = HttpContext.Current;

            restaurant.meals["normal"] = HelperFunctions.GetNumberOfNormalMeals(restaurant.numberOfMeals, restaurant.meals);

            if (ctx != null)
            {
                try
                {
                    List<Restaurant> list = (List<Restaurant>)ctx.Cache[CacheKey];
                    list.Add(restaurant);
                    list = (from s in list orderby s.rating descending select s).ToList();
                    ctx.Cache[CacheKey] = list;

                    return true;
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
    }
}