using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Models.StaticDataModels
{
    public class ChampionSkin
    {
        public String id { get; set; }
        public float num { get; set; }
        public String name { get; set; }
        public bool chromas { get; set; }
    }
}