using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Models
{
    public class PlayerData
    {
        public String currentPlatformId { get; set; }
        public String summonerName { get; set; }
        public String matchHistoryUri { get; set; }
        public String platformId { get; set; }
        public String currentAccountId { get; set; }
        public int profileIcon { get; set; }
        public String summonerId { get; set; }
        public String accountId { get; set; }
    }
}