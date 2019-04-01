using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VizworxAPI.Models
{
    public class Restaurant
    {
        public string name;
        public int rating;
        public int numberOfMeals;
        public Dictionary<string, int> meals { get; set; }

        public Restaurant() { }
    }
}