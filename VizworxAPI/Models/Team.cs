using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VizworxAPI.Models
{
    public class Team
    {
        public int numberOfMembers { get; set; }
        public Dictionary<string, int> meals { get; set; }

        public Team() { }
    }
}