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
    }
}