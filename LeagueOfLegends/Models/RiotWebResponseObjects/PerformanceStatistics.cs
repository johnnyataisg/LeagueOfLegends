﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Models
{
    public class PerformanceStatistics
    {
        public int participantId { get; set; }
        public bool win { get; set; }
        public int kills { get; set; }
        public int deaths { get; set; }
        public int assists { get; set; }
        public int totalMinionsKilled { get; set; }
        public int goldEarned { get; set; }
        public int goldSpent { get; set; }
        public int totalScoreRank { get; set; }
        public int totalPlayerScore { get; set; }
        public int champLevel { get; set; }
        public int neutralMinionsKilled { get; set; }
        public int neutralMinionsKilledTeamJungle { get; set; }
        public int neutralMinionsKilledEnemyJungle { get; set; }
        public int physicalDamageDealtToChampions { get; set; }
        public int physicalDamageDealt { get; set; }
        public int largestCriticalStrike { get; set; }
        public int magicDamageDealtToChampions { get; set; }
        public int magicDamageDealt { get; set; }
        public int trueDamageDealtToChampions { get; set; }
        public int trueDamageDealt { get; set; }
        public int totalDamageDealtToChampions { get; set; }
        public int totalDamageDealt { get; set; }
        public int visionScore { get; set; }
        public int wardsKilled { get; set; }
        public int sightWardsBoughtInGame { get; set; }
        public int visionWardsBoughtInGame { get; set; }
        public int wardsPlaced { get; set; }
        public int totalUnitsHealed { get; set; }
        public int totalHeal { get; set; }
        public int timeCCingOthers { get; set; }
        public int totalTimeCrowdControlDealt { get; set; }
        public int physicalDamageTaken { get; set; }
        public int magicalDamageTaken { get; set; }
        public int trueDamageTaken { get; set; }
        public int damageSelfMitigated { get; set; }
        public int totalDamageTaken { get; set; }
        public int objectivePlayerScore { get; set; }
        public int damageDealtToTurrets { get; set; }
        public bool firstTowerAssist { get; set; }
        public bool firstTowerKill { get; set; }
        public int damageDealtToObjectives { get; set; }
        public bool firstInhibitorKills { get; set; }
        public int turretKills { get; set; }
        public int inhibitorKills { get; set; }
        public bool firstInhibitorAssist { get; set; }
        public int combatPlayerScore { get; set; }
        public bool firstBloodKill { get; set; }
        public bool firstBloodAssist { get; set; }
        public int killingSprees { get; set; }
        public int largestKillingSpree { get; set; }
        public int unrealKills { get; set; }
        public int doubleKills { get; set; }
        public int tripleKills { get; set; }
        public int quadraKills { get; set; }
        public int pentaKills { get; set; }
        public int largestMultiKill { get; set; }
        public int longestTimeSpentLiving { get; set; }
        public int item0 { get; set; }
        public int item1 { get; set; }
        public int item2 { get; set; }
        public int item3 { get; set; }
        public int item4 { get; set; }
        public int item5 { get; set; }
        public int item6 { get; set; }
        public int perkPrimaryStyle { get; set; }
        public int perkSubStyle { get; set; }
        public int perk0 { get; set; }
        public int perk0Var1 { get; set; }
        public int perk0Var2 { get; set; }
        public int perk0Var3 { get; set; }
        public int perk1 { get; set; }
        public int perk1Var1 { get; set; }
        public int perk1Var2 { get; set; }
        public int perk1Var3 { get; set; }
        public int perk2 { get; set; }
        public int perk2Var1 { get; set; }
        public int perk2Var2 { get; set; }
        public int perk2Var3 { get; set; }
        public int perk3 { get; set; }
        public int perk3Var1 { get; set; }
        public int perk3Var2 { get; set; }
        public int perk3Var3 { get; set; }
        public int perk4 { get; set; }
        public int perk4Var1 { get; set; }
        public int perk4Var2 { get; set; }
        public int perk4Var3 { get; set; }
        public int perk5 { get; set; }
        public int perk5Var1 { get; set; }
        public int perk5Var2 { get; set; }
        public int perk5Var3 { get; set; }
        public int statPerk0 { get; set; }
        public int statPerk1 { get; set; }
        public int statPerk2 { get; set; }
        public int playerScore0 { get; set; }
        public int playerScore1 { get; set; }
        public int playerScore2 { get; set; }
        public int playerScore3 { get; set; }
        public int playerScore4 { get; set; }
        public int playerScore5 { get; set; }
        public int playerScore6 { get; set; }
        public int playerScore7 { get; set; }
        public int playerScore8 { get; set; }
        public int playerScore9 { get; set; }
    }
}