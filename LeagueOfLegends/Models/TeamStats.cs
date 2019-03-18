using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Models
{
    public class TeamStats
    {
        public bool firstDragon { get; set; }
        public List<ChampionBan> bans { get; set; }
        public bool firstInhibitor { get; set; }
        public String win { get; set; }
        public bool firstRiftHerald { get; set; }
        public bool firstBaron { get; set; }
        public int baronKills { get; set; }
        public int riftHeraldKills { get; set; }
        public int teamId { get; set; }
        public bool firstTower { get; set; }
        public int vilemawKills { get; set; }
        public int inhibitorKills { get; set; }
        public int towerKills { get; set; }
        public int dominionVictoryScore { get; set; }
        public int dragonKills { get; set; }
    }
}