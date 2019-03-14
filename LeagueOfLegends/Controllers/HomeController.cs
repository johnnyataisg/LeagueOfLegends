﻿using LeagueOfLegends.Models;
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

namespace LeagueOfLegends.Controllers
{
    public class HomeController : Controller
    {
        private String api_key = "RGAPI-fefd048e-3982-463e-a720-aa6ad6b4c9f1";

        public ActionResult Index(String message)
        {
            ViewBag.message = message;
            return View();
        }

        [HttpGet]
        public ActionResult Profile(String sName)
        {
            try
            {
                String summonerName = sName;
                if (summonerName == null || summonerName == "")
                {
                    return RedirectToAction("Index", "Home", new { message = "Please enter the name of a summoner" });
                }
                Uri targetUri = new Uri("https://na1.api.riotgames.com/lol/summoner/v4/summoners/by-name/" + summonerName + "?api_key=" + api_key);
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(targetUri);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                String objText = reader.ReadToEnd();
                Summoner summoner = JsonConvert.DeserializeObject<Summoner>(objText);

                String accountID = summoner.accountID;
                targetUri = new Uri("https://na1.api.riotgames.com/lol/match/v4/matchlists/by-account/" + accountID + "?api_key=" + api_key);
                request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(targetUri);
                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream());
                objText = reader.ReadToEnd();
                MatchList matchList = JsonConvert.DeserializeObject<MatchList>(objText);

                var summonerData = new Tuple<Summoner, MatchList>(summoner, matchList);

                return View(summonerData);
            }
            catch (Exception exception)
            {
                ViewBag.errorMsg = "Summoner not found. Please try another summoner ID";
                return View();
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}