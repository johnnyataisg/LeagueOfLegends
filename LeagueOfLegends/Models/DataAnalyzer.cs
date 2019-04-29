using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Models
{
    public class DataAnalyzer
    {
        private List<MatchData> matchDataList = new List<MatchData>();

        public DataAnalyzer(MatchList matches, int listLength)
        {
            for (int i = 0; i < listLength; i++)
            {
                Match match = matches.matches.ElementAt(i);
                RiotRestWrapper client = new RiotRestWrapper("https://na1.api.riotgames.com/lol/match/v4/matches/" + match.gameId.ToString());
                IRestResponse response = client.Execute();
                matchDataList.Add(JsonConvert.DeserializeObject<MatchData>(response.Content.ToString()));
            }
        }

        public Dictionary<String, double> calculateAverageStats(String accountID)
        {
            Dictionary<String, double> statsMatrix = new Dictionary<String, double>();
            statsMatrix.Add("winrate", this.calculateWinRate(accountID));
            statsMatrix.Add("kills", this.calculateAverageKills(accountID));
            statsMatrix.Add("deaths", this.calculateAverageDeaths(accountID));
            statsMatrix.Add("assists", this.calculateAverageAssists(accountID));
            statsMatrix.Add("minionscore", this.calculateAverageMinionScore(accountID));
            return statsMatrix;
        }

        public double calculateWinRate(String accountID)
        {
            double wins = 0;
            double losses = 0;
            foreach (MatchData matchData in this.matchDataList)
            {
                if (matchData.getMatchResultForPlayer(accountID).Equals("Win"))
                {
                    wins++;
                }
                else
                {
                    losses++;
                }
            }
            double winRatio = Math.Round(Convert.ToDouble(wins / (wins + losses)) * 100, 2);
            return winRatio;
        }

        public double calculateAverageKills(String accountID)
        {
            double kills = 0;
            double i = 0;
            foreach (MatchData matchData in this.matchDataList)
            {
                kills += matchData.getKillsForPlayer(accountID);
                i++;
            }
            double averageKills = Math.Round(Convert.ToDouble(kills / i));
            return averageKills;
        }

        public double calculateAverageDeaths(String accountID)
        {
            double deaths = 0;
            double i = 0;
            foreach (MatchData matchData in this.matchDataList)
            {
                deaths += matchData.getDeathsForPlayer(accountID);
                i++;
            }
            double averageDeaths = Math.Round(Convert.ToDouble(deaths / i));
            return averageDeaths;
        }

        public double calculateAverageAssists(String accountID)
        {
            double assists = 0;
            double i = 0;
            foreach (MatchData matchData in this.matchDataList)
            {
                assists += matchData.getAssistsForPlayer(accountID);
                i++;
            }
            double averageAssists = Math.Round(Convert.ToDouble(assists / i));
            return averageAssists;
        }

        public double calculateAverageMinionScore(String accountID)
        {
            double cs = 0;
            double i = 0;
            foreach (MatchData matchData in this.matchDataList)
            {
                cs += matchData.getMinionScoreForPlayer(accountID);
                i++;
            }
            double averageCS = Math.Round(Convert.ToDouble(cs / i));
            return averageCS;
        }

        private Dictionary<String, ParticipantPerformance> getMatchDataForPlayer(String accountID)
        {
            Dictionary<String, ParticipantPerformance> summonerStatsPerMatch = new Dictionary<String, ParticipantPerformance>();
            this.loadPlayerStats(summonerStatsPerMatch, accountID);
            return summonerStatsPerMatch;
        }

        private void loadPlayerStats(Dictionary<String, ParticipantPerformance> statsContainer, String accountID)
        {
            foreach (MatchData data in this.matchDataList)
            {
                ParticipantPerformance playerMatchStats = data.findPerformanceStatsForPlayer(accountID);
                statsContainer.Add(data.gameId.ToString(), playerMatchStats);
            }
        }
    }
}