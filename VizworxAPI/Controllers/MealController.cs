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
    public class MealController : ApiController
    {
        private TeamController tc;
        private RestaurantController rc;
        private MealRepository mealRepoistory;

        public MealController()
        {
            tc = new TeamController();
            rc = new RestaurantController();
            mealRepoistory = new MealRepository();
        }

        // GET: api/Meal
        public Dictionary<string, Dictionary<string, int>> Get()
        {
            Team team = tc.Get();
            List<Restaurant> restaurants = rc.Get();

            return mealRepoistory.GetMealOrder(team, restaurants);
        }
    }
}