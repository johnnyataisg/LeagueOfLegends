using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Models.DTO
{
	public class SummonerProfileDTO
	{
        public Summoner summoner { get; set; }
		public MatchList matchList { get; set; }
		public String accountID { get; set; }
		public List<SummonerLeague> leagues { get; set; }
		public List<ChampionMastery> championMasteries { get; set; }
		public List<ChampionSummary> bestChampions { get; set; }
		public ProfileIcon icon { get; set; }
		public Dictionary<long, MatchData> matchDictionary { get; set; }
	}
}