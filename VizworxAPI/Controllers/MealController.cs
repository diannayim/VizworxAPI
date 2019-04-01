using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VizworxAPI.Models;
using VizworxAPI.Services;

namespace VizworxAPI.Controllers
{
    /// <summary>
    /// Controller for meal orders.
    /// </summary>
    public class MealController : ApiController
    {
        // Private variables.
        private TeamController tc;
        private RestaurantController rc;
        private MealRepository mealRepoistory;

        /// <summary>
        /// Constructor for meal controller. Instantiate needed variables.
        /// </summary>
        public MealController()
        {
            tc = new TeamController();
            rc = new RestaurantController();
            mealRepoistory = new MealRepository();
        }

        /// <summary>
        /// Returns meal order given the team and list of restaurants saved within the HTTP Context.
        /// </summary>
        /// <returns>Meal order for each restaurant.</returns>
        public Dictionary<string, Dictionary<string, int>> Get()
        {
            Team team = tc.Get();
            List<Restaurant> restaurants = rc.Get();

            return mealRepoistory.GetMealOrder(team, restaurants);
        }
    }
}