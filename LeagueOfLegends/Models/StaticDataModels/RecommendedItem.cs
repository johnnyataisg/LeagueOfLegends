using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Models.StaticDataModels
{
    public class RecommendedItem
    {
        public String id { get; set; }
        public float count { get; set; }
        public bool hideCount { get; set; }
    }
}