using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Models.StaticDataModels
{
    public class ChampionImage
    {
        public String full { get; set; }
        public String sprite { get; set; }
        public String group { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float w { get; set; }
        public float h { get; set; }
    }
}