using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VizworxAPI.Models
{
    /// <summary>
    /// Restaurant object that contains unique name of restaurant, rating, number of meals and special meals.
    /// </summary>
    public class Restaurant
    {
        public string name;
        public int rating;
        public int numberOfMeals;
        public Dictionary<string, int> meals { get; set; }

        public Restaurant() { }
    }
}