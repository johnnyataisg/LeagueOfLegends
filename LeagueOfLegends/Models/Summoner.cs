using System;
using System.Collections;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Models
{
    public class Summoner
    {
        public String id { get; set; }
        public String accountID { get; set; }
        public String puuid { get; set; }
        public String name { get; set; }
        public int profileIconId { get; set; }
        public long revisionDate { get; set; }
        public int summonerLevel { get; set; }
    }
}