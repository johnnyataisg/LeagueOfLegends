using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LeagueOfLegends.Models.DTO;

namespace LeagueOfLegends.Models
{
    public class Cache : Dictionary<String, SummonerProfileDTO>
    {
        public SummonerProfileDTO retrieveData(String summonerName)
        {
            return this[summonerName];
        }

        public void addSummonerProfileToCache(String summonerName, SummonerProfileDTO summonerProfile)
        {
            this.Add(summonerName, summonerProfile);
        }
    }
}