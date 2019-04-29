using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Models.StaticDataModels
{
    public class ChampionSpell
    {
        public String id { get; set; }
        public String name { get; set; }
        public String description { get; set; }
        public String tooltip { get; set; }
        public SpellLevelTip leveltip { get; set; }
        public float maxrank { get; set; }
        public List<float> cooldown { get; set; }
        public String cooldownBurn { get; set; }
        public List<float> cost { get; set; }
        public String costBurn { get; set; }
        public Object datavalues { get; set; }
        public List<List<float>> effect { get; set; }
        public List<String> effectBurn { get; set; }
        public List<Object> vars { get; set; }
        public String costType { get; set; }
        public String maxammo { get; set; }
        public List<float> range { get; set; }
        public String rangeBurn { get; set; }
        public SpellImage image { get; set; }
        public String resource { get; set; }
    }
}