using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Models
{
    public class ParticipantPerformance
    {
        public PerformanceStatistics stats { get; set; }
        public int spell1Id { get; set; }
        public int spell2Id { get; set; }
        public int participantId { get; set; }
        public String highestAchievedSeasonTier { get; set; }
        public int teamId { get; set; }
        public PerformanceTimeline timeline { get; set; }
        public int championId { get; set; }
    }
}