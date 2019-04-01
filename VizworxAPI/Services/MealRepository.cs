using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VizworxAPI.Models;

namespace VizworxAPI.Services
{
    public class MealRepository
    {
        public MealRepository ()
        {

        }

        public Dictionary<string, Dictionary<string, int>> GetMealOrder(Team team, List<Restaurant> restaurants)
        {
            Dictionary<string, Dictionary<string, int>> mealOrder = new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, int> order = team.meals;

            foreach (string key in order.Keys)
            {
                int mealsLeft = order[key];

                foreach (Restaurant r in restaurants)
                {
                    if (!r.meals.ContainsKey(key))
                        continue;

                    if (!mealOrder.ContainsKey(r.name))
                    {
                        mealOrder[r.name] = new Dictionary<string, int>();
                    }

                    int meals;

                    if (mealsLeft > r.meals[key])
                    {
                        meals = r.meals[key];
                    }

                    else
                    {
                        meals = mealsLeft;
                    }

                    mealsLeft -= meals;
                    mealOrder[r.name][key] = meals;

                    if (mealsLeft == 0)
                        break;
                }
            }

            return mealOrder;
        }
    }
}