using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Models
{
    public class Match
    {
        public String platformId { get; set; }
        public long gameId { get; set; }
        public int champion { get; set; }
        public int queue { get; set; }
        public int season { get; set; }
        public long timestamp { get; set; }
        public String role { get; set; }
        public String lane { get; set; }
    }
}