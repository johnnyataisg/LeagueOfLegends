using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Models.DTO
{
    public class RankedMapDto : Dictionary<String, SummonerLeague>
    {
        public static String RANKED_SOLO = "RANKED_SOLO_5x5";
        public static String RANKED_FLEX = "RANKED_FLEX_SR";
        public static String RANKED_3V3 = "RANKED_FLEX_TT";

        private static Dictionary<String, String> rankedEmblemMap = new Dictionary<String, String>()
        {
            ["UNRANKED"] = "unranked_1.png",
            ["IRON"] = "iron_1.png",
            ["BRONZE"] = "bronze_1.png",
            ["SILVER"] = "silver_1.png",
            ["GOLD"] = "gold_1.png",
            ["PLATINUM"] = "platinum_1.png",
            ["DIAMOND"] = "diamond_1.png",
            ["GRANDMASTER"] = "grandmaster_1.png",
            ["CHALLENGER"] = "challenger_1.png"
        };

        public RankedMapDto(List<SummonerLeague> rankedQueues)
        {
            foreach (SummonerLeague rankedQueue in rankedQueues)
            {
                this.Add(rankedQueue.queueType, rankedQueue);
            }
        }

        public bool HasDataForRank(String queueType)
        {
            return this.ContainsKey(queueType);
        }

        public String GetRankedEmblemFor(String queueType)
        {
            return rankedEmblemMap[GetTierFor(queueType)];
        }

        public String GetTierFor(String queueType)
        {
            return HasDataForRank(queueType) ? this[queueType].tier : "UNRANKED";
        }

        public String GetDivisionFor(String queueType)
        {
            return HasDataForRank(queueType) ? this[queueType].rank : "N/A";
        }

        public int GetPointsFor(String queueType)
        {
            return HasDataForRank(queueType) ? this[queueType].leaguePoints : 0;
        }

        public int GetWinsFor(String queueType)
        {
            return HasDataForRank(queueType) ? this[queueType].wins : 0;
        }

        public int GetLossesFor(String queueType)
        {
            return HasDataForRank(queueType) ? this[queueType].losses : 0;
        }

        public decimal CalculateWinRateFor(String queueType)
        {
            return HasDataForRank(queueType) ? Decimal.Round((GetWinsFor(queueType) / GetLossesFor(queueType)), 2) : 0;
        }
    }
}