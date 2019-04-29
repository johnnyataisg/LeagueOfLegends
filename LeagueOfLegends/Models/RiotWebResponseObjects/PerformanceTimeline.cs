using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Models
{
    public class PerformanceTimeline
    {
        public String lane { get; set; }
        public String role { get; set; }
        public int participantId { get; set; }
        public Dictionary<String, double> csdDiffPerMinDeltas { get; set; }
        public Dictionary<String, double> goldPerMinDeltas { get; set; }
        public Dictionary<String, double> xpDiffPerMinDeltas { get; set; }
        public Dictionary<String, double> creepsPerMinDeltas { get; set; }
        public Dictionary<String, double> xpPerMinDeltas { get; set; }
        public Dictionary<String, double> damageTakenDiffPerMinDeltas { get; set; }
        public Dictionary<String, double> damageTakenPerMinDeltas { get; set; }
    }
}