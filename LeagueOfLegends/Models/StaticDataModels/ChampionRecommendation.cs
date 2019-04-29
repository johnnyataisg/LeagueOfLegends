using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Models.StaticDataModels
{
    public class ChampionRecommendation
    {
        public String champion { get; set; }
        public String title { get; set; }
        public String map { get; set; }
        public String mode { get; set; }
        public String type { get; set; }
        public String customTag { get; set; }
        public float sortrank { get; set; }
        public bool extensionPage { get; set; }
        public bool useObviousCheckmark { get; set; }
        public String customPanel { get; set; }
        public List<Block> blocks { get; set; }
    }
}