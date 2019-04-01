using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VizworxAPI
{
    /// <summary>
    /// Helper logic functions that are needed by multiple classes.
    /// </summary>
    public static class HelperFunctions
    {
        /// <summary>
        /// Returns number of normal meals as needed.
        /// </summary>
        /// <param name="totalMeals">Total number of meals.</param>
        /// <param name="special">Dictionary of special meals.</param>
        /// <returns>Dictionary of meals including normal ones.</returns>
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