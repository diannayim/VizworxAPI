using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using VizworxAPI.Models;
using VizworxAPI.Services;

namespace VizworxAPI.Controllers
{
    /// <summary>
    /// Controller for team.
    /// </summary>
    public class TeamController : ApiController
    {
        private TeamRepository teamRepository;

        public TeamController()
        {
            this.teamRepository = new TeamRepository();
        }

        public Team Get()
        {
            return teamRepository.GetTeam();
        }

        // POST: api/Team
        public void Post(HttpRequestMessage request)
        {
            string json = request.Content.ReadAsStringAsync().Result;
            Team team = JsonConvert.DeserializeObject<Team>(json);
            this.teamRepository.SaveTeam(team);
        }
    }
}
