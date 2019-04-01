using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VizworxAPI
{
    public static class HelperFunctions
    {
        public static int GetNumberOfNormalMeals(int totalMeals, Dictionary<string, int> special)
        {
            int specialCount = 0;

            foreach(string key in special.Keys)
            {
                specialCount += special[key];
            }

            return totalMeals - specialCount;
        }

    }
}