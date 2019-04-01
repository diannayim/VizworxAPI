using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VizworxAPI.Models;

namespace VizworxAPI.Services
{
    /// <summary>
    /// Class which holds the logic of Meal Orders.
    /// </summary>
    public class MealRepository
    {
        /// <summary>
        /// Creates a meal repository.
        /// </summary>
        public MealRepository () { }

        /// <summary>
        /// Gets a meal order for a team from given list of restaurants.
        /// </summary>
        /// <param name="team">Team that needs food.</param>
        /// <param name="restaurants">List of restaurants ordered by rating.</param>
        /// <returns>Name of Restaurant with the meals for each one.</returns>
        public Dictionary<string, Dictionary<string, int>> GetMealOrder(Team team, List<Restaurant> restaurants)
        {
            // Key:     Name of Restaurant
            // Value:   Dictionary of meal orders. Key is name of meal type, int is number of meals.
            Dictionary<string, Dictionary<string, int>> mealOrder = new Dictionary<string, Dictionary<string, int>>();

            // Original order required from team.
            Dictionary<string, int> order = team.meals;

            // Traverse each meal type in order.
            foreach (string key in order.Keys)
            {
                // The number of meals needed from order with type "key".
                int mealsLeft = order[key];

                // Traverse through each restaurant in order of rating.
                foreach (Restaurant r in restaurants)
                {
                    // If restaurant doesn't have that type of meal, continue to next.
                    if (!r.meals.ContainsKey(key))
                        continue;

                    // If the mealOrder dictionary does not have the restaurant added, create new Dictionary for it.
                    if (!mealOrder.ContainsKey(r.name))
                    {
                        mealOrder[r.name] = new Dictionary<string, int>();
                    }
                    
                    int meals;

                    // If there are more meals left than the restaurant has to offer, consume all of the restaurant's meal of that type.
                    if (mealsLeft > r.meals[key])
                    {
                        meals = r.meals[key];
                    }

                    // Otherwise, consume what is left.
                    else
                    {
                        meals = mealsLeft;
                    }

                    // Subtract the number of meals consumed from the restaurant to the number of meals needed.
                    mealsLeft -= meals;

                    // Add to meal order.
                    mealOrder[r.name][key] = meals;

                    // If no more meals of that type is needed, move onto next type.
                    if (mealsLeft == 0)
                        break;
                }
            }

            // Return the meal order.
            return mealOrder;
        }
    }
}