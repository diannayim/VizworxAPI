using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VizworxAPI.Models;

namespace VizworxAPI.Services
{
    public class TeamRepository
    {
        private const string CacheKey = "Team";

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

        public Team GetTeam()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (Team)ctx.Cache[CacheKey];
            }

            return new Team();
        }

        public bool SaveTeam(Team team)
        {
            var ctx = HttpContext.Current;

            team.meals["normal"] = HelperFunctions.GetNumberOfNormalMeals(team.numberOfMembers, team.meals);

            if (ctx != null)
            {
                try
                {
                    ctx.Cache[CacheKey] = team;

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