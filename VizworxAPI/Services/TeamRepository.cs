using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VizworxAPI.Models;

namespace VizworxAPI.Services
{
    /// <summary>
    /// Class which holds the logic for Teams.
    /// </summary>
    public class TeamRepository
    {
        /// <summary>
        /// Cache key needed for data storage within HTTP Context.
        /// </summary>
        private const string CacheKey = "Team";

        /// <summary>
        /// Creates a team repository and sets up an empty list of restaurants.
        /// </summary>
        public TeamRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    ctx.Cache[CacheKey] = new Team();
                }
            }
        }

        /// <summary>
        /// Gets team from HTTP Context.
        /// </summary>
        /// <returns>Team.</returns>
        public Team GetTeam()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (Team)ctx.Cache[CacheKey];
            }

            return new Team();
        }

        /// <summary>
        /// Saves team to HTTP Context.
        /// </summary>
        /// <param name="team">Team to save.</param>
        /// <returns></returns>
        public void SaveTeam(Team team)
        {
            var ctx = HttpContext.Current;

            team.meals["normal"] = HelperFunctions.GetNumberOfNormalMeals(team.numberOfMembers, team.meals);

            if (ctx != null)
            {
                ctx.Cache[CacheKey] = team;
            }

        }
    }
}