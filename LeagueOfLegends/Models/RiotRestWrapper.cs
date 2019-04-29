using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Models
{
    public class RiotRestWrapper
    {
        private RestClient client;
        private RestRequest request;
        private static String api_key = "RGAPI-e1688917-7e74-413a-aaad-404483f9fce6";

        public RiotRestWrapper(String url)
        {
            this.client = new RestClient(url);
            this.request = new RestRequest(Method.GET);
            request.AddHeader("Origin", "https://developer.riotgames.com");
            request.AddHeader("Accept-Charset", "application/x-www-form-urlencoded; charset=UTF-8");
            request.AddHeader("X-Riot-Token", api_key);
            request.AddHeader("Accept-Language", "en-US,en;q=0.9");
            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Safari/537.36");
        }

        public IRestResponse Execute()
        {
            return this.client.Execute(this.request);
        }

        public static String getKey()
        {
            return api_key;
        }
    }
}