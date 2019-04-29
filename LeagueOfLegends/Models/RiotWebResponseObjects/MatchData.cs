using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Models
{
    public class MatchData
    {
        public int seasonId { get; set; }
        public int queueId { get; set; }
        public long gameId { get; set; }
        public List<Player> participantIdentities { get; set; }
        public String gameVersion { get; set; }
        public String platformId { get; set; }
        public String gameMode { get; set; }
        public int mapId { get; set; }
        public String gameType { get; set; }
        public List<TeamStats> teams { get; set; }
        public List<ParticipantPerformance> participants { get; set; }
        public int gameDuration { get; set; }
        public long gameCreation { get; set; }

        public String getMatchResultForPlayer(String accountID)
        {
            ParticipantPerformance playerPerformance = this.findPerformanceStatsForPlayer(accountID);
            return this.getMatchResultForTeam(playerPerformance.teamId);
        }

        public String getMatchResultForTeam(int teamID)
        {
            foreach (TeamStats team in this.teams)
            {
                if (team.teamId == teamID)
                {
                    return team.win;
                }
            }
            return null;
        }

        public int getKillsForPlayer(String accountID)
        {
            return this.findPerformanceStatsForPlayer(accountID).stats.kills;
        }

        public int getDeathsForPlayer(String accountID)
        {
            return this.findPerformanceStatsForPlayer(accountID).stats.deaths;
        }

        public int getAssistsForPlayer(String accountID)
        {
            return this.findPerformanceStatsForPlayer(accountID).stats.assists;
        }

        public int getMinionScoreForPlayer(String accountID)
        {
            return this.findPerformanceStatsForPlayer(accountID).stats.totalMinionsKilled;
        }

        public ParticipantPerformance findPerformanceStatsForPlayer(String accountID)
        {
            int participantID = this.findParticipantIdForPlayer(accountID);

            foreach (ParticipantPerformance performanceStat in this.participants)
            {
                if (performanceStat.participantId == participantID)
                {
                    return performanceStat;
                }
            }
            return null;
        }

        private int findParticipantIdForPlayer(String accountID)
        {
            foreach (Player player in this.participantIdentities)
            {
                if (player.player.currentAccountId.Equals(accountID))
                {
                    return player.participantId;
                }
            }
            return 0;
        }
    }
}