using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Models
{
    public class SummonerLeague
    {
        public String queueType { get; set; }
        public String summonerName { get; set; }
        public bool hotStreak { get; set; }
        public int wins { get; set; }
        public bool veteran { get; set; }
        public int losses { get; set; }
        public String rank { get; set; }
        public String tier { get; set; }
        public bool inactive { get; set; }
        public bool freshBlood { get; set; }
        public String leagueId { get; set; }
        public String summonerId { get; set; }
        public int leaguePoints { get; set; }
    }
}