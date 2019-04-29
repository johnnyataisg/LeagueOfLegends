using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Models.StaticDataModels
{
    public class ChampionData
    {
        public String id { get; set; }
        public String key { get; set; }
        public String name { get; set; }
        public String title { get; set; }
        public ChampionImage image { get; set; }
        public List<ChampionSkin> skins { get; set; }
        public String lore { get; set; }
        public String blurb { get; set; }
        public List<String> allytips { get; set; }
        public List<String> enemytips { get; set; }
        public List<String> tags { get; set; }
        public String partype { get; set; }
        public ChampionInfo info { get; set; }
        public ChampionStats stats { get; set; }
        public List<ChampionSpell> spells { get; set; }
        public ChampionPassive passive { get; set; }
        public List<ChampionRecommendation> recommended { get; set; }

    }
}