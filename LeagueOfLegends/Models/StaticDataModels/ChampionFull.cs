using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Models.StaticDataModels
{
    public class ChampionFull
    {
        public String type { get; set; }
        public String format { get; set; }
        public String version { get; set; }
        public Dictionary<String, ChampionData> data { get; set; }
        public Dictionary<String, String> keys { get; set; }
    }
}