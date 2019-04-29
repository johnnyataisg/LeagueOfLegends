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

namespace LeagueOfLegends.Controllers
{
    public class HomeController : Controller
    {
        private LeagueOfLegendsStaticDataEntities db = new LeagueOfLegendsStaticDataEntities();

        public ActionResult Index(String message)
        {
            ViewBag.message = message;
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
                Summoner summoner = JsonConvert.DeserializeObject<Summoner>(response.Content.ToString());

                //Get the 100 most recent games of this summoner
                String accountID = summoner.accountId;
                client = new RiotRestWrapper("https://na1.api.riotgames.com/lol/match/v4/matchlists/by-account/" + accountID);
                response = client.Execute();
                MatchList matchList = JsonConvert.DeserializeObject<MatchList>(response.Content.ToString());

                ViewBag.summoner = summoner;
                ViewBag.matchList = matchList;
                ViewBag.accountID = accountID;

                return View();
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
            return View(db.Champions.ToList());
        }
    }
}