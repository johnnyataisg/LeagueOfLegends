using LeagueOfLegends.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.Entity;
using System.Web.Security;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace LeagueOfLegends.Controllers
{
    public class HomeController : Controller
    {
        static private DatabaseEntity db = new DatabaseEntity();
        private Dictionary<int, ChampionSummary> championDictionary = db.ChampionSummary.Include("ChampionImage").Include("ChampionPassive.PassiveImage").ToDictionary(row => row.key);
        private Dictionary<String, ChampionSummary> championDictionary2 = db.ChampionSummary.Include("ChampionImage").Include("ChampionPassive.PassiveImage").ToDictionary(row => row.id);

        public ActionResult Index(String message)
        {
            ViewData["Message"] = message;
            return View();
        }

        [HttpGet]
        public ActionResult SummonerProfile(String sName)
        {
            try
            {
                //Redirect to index and show error message if the summoner name is null or empty
                if (sName == null || sName == "")
                {
                    return RedirectToAction("Index", "Home", new { message = "Please enter the name of a summoner" });
                }

                //Get the summoner Riot API response object
                RiotRestWrapper client = new RiotRestWrapper("https://na1.api.riotgames.com/lol/summoner/v4/summoners/by-name/" + sName);
                IRestResponse response = client.Execute();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return RedirectToAction("Index", "Home", new { message = "There was an error processing your request, most likely due to rate restrictions" });
                }
                Summoner summoner = JsonConvert.DeserializeObject<Summoner>(response.Content.ToString());

                //Get the 100 most recent games of this summoner
                String accountID = summoner.accountId;
                client = new RiotRestWrapper("https://na1.api.riotgames.com/lol/match/v4/matchlists/by-account/" + accountID + "?endIndex=20");
                response = client.Execute();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return RedirectToAction("Index", "Home", new { message = "There was an error processing your request, most likely due to rate restrictions" });
                }
                MatchList matchList = JsonConvert.DeserializeObject<MatchList>(response.Content.ToString());

                //Create a dictionary for all match data
                Dictionary<long, MatchData> matchDictionary = new Dictionary<long, MatchData>();
                foreach (Match match in matchList.matches)
                {
                    client = new RiotRestWrapper("https://na1.api.riotgames.com/lol/match/v4/matches/" + match.gameId);
                    response = client.Execute();
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        return RedirectToAction("Index", "Home", new { message = "There was an error processing your request, most likely due to rate restrictions" });
                    }
                    MatchData data = JsonConvert.DeserializeObject<MatchData>(response.Content.ToString());
                    matchDictionary.Add(match.gameId, data);
                }

                ViewData["Summoner"] = summoner;
                ViewData["Matchlist"] = matchList;
                ViewData["AccountID"] = accountID;
                ViewData["MatchDictionary"] = matchDictionary;

                return View(this.championDictionary);
            }
            catch (Exception exception)
            {
                return RedirectToAction("Index", "Home", new { message = exception.Message });
            }
        }

        public ActionResult MatchDetails(String matchId, int championId)
        {
            try
            {
                RiotRestWrapper client = new RiotRestWrapper("https://na1.api.riotgames.com/lol/match/v4/matches/" + matchId);
                IRestResponse response = client.Execute();
                MatchData data = JsonConvert.DeserializeObject<MatchData>(response.Content.ToString());

                ViewBag.champion = championId;

                return View(data);
            }
            catch (Exception exception)
            {
                return RedirectToAction("Index", "Home", new { message = exception.Message });
            }
        }

        public ActionResult AllChampions()
        {
            return View(this.championDictionary2);
        }

        public ActionResult ChampionData(String championID)
        {
            ChampionSummary champion = this.championDictionary2[championID];
            ChampionInfo championInfo = db.ChampionInfo.SingleOrDefault(row => row.championKey == champion.key);
            ChampionType[] championTypes = db.ChampionTypes.Where(row => row.championKey == champion.key).ToArray();
            ChampionSpell[] championSpells = db.ChampionSpells.Include("SpellImage").Where(row => row.championKey == champion.key).OrderBy(row => row.image).ToArray();
            String championTypeString = null;
            for (int i = 0; i < championTypes.Count(); i++)
            {
                if (i == 0)
                {
                    championTypeString += championTypes[i].description;
                }
                else
                {
                    championTypeString += ", " + championTypes[i].description;
                }
            }
            ViewData["ChampionInfo"] = championInfo;
            ViewData["ChampionSpells"] = championSpells;
            ViewData["ChampionTypeString"] = championTypeString;

            return View(champion);
        }
    }
}