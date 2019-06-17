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
        private Dictionary<long, MatchData> matchDataList = new Dictionary<long, MatchData>();

        public DataAnalyzer(Dictionary<long, MatchData> matches)
        {
            this.matchDataList = matches;
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
            foreach (KeyValuePair<long, MatchData> matchData in this.matchDataList)
            {
                if (matchData.Value.getMatchResultForPlayer(accountID).Equals("Win"))
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
            foreach (KeyValuePair<long, MatchData> matchData in this.matchDataList)
            {
                kills += matchData.Value.getKillsForPlayer(accountID);
                i++;
            }
            double averageKills = Math.Round(Convert.ToDouble(kills / i));
            return averageKills;
        }

        public double calculateAverageDeaths(String accountID)
        {
            double deaths = 0;
            double i = 0;
            foreach (KeyValuePair<long, MatchData> matchData in this.matchDataList)
            {
                deaths += matchData.Value.getDeathsForPlayer(accountID);
                i++;
            }
            double averageDeaths = Math.Round(Convert.ToDouble(deaths / i));
            return averageDeaths;
        }

        public double calculateAverageAssists(String accountID)
        {
            double assists = 0;
            double i = 0;
            foreach (KeyValuePair<long, MatchData> matchData in this.matchDataList)
            {
                assists += matchData.Value.getAssistsForPlayer(accountID);
                i++;
            }
            double averageAssists = Math.Round(Convert.ToDouble(assists / i));
            return averageAssists;
        }

        public double calculateAverageMinionScore(String accountID)
        {
            double cs = 0;
            double i = 0;
            foreach (KeyValuePair<long, MatchData> matchData in this.matchDataList)
            {
                cs += matchData.Value.getMinionScoreForPlayer(accountID);
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
            foreach (KeyValuePair<long, MatchData> matchData in this.matchDataList)
            {
                ParticipantPerformance playerMatchStats = matchData.Value.findPerformanceStatsForPlayer(accountID);
                statsContainer.Add(matchData.Value.gameId.ToString(), playerMatchStats);
            }
        }
    }
}