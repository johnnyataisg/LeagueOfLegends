using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Models.StaticDataModels
{
    public class Block
    {
        public String type { get; set; }
        public bool recMath { get; set; }
        public bool recSteps { get; set; }
        public int minSummonerLevel { get; set; }
        public int maxSummonerLevel { get; set; }
        public String showIfSummonerSpell { get; set; }
        public String hideIfSummonerSpell { get; set; }
        public String appendAfterSection { get; set; }
        public List<String> visibleWithAllOf { get; set; }
        public List<String> hiddenWithAnyOf { get; set; }
        public List<RecommendedItem> items { get; set; }
    }
}