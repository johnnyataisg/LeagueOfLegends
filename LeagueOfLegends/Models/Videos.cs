using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Models
{
    public class Videos
    {
        private Dictionary<String, String> videoMap;

        public Videos()
        {
            this.videoMap = new Dictionary<String, String>();
            videoMap.Add("Aatrox", "https://www.youtube.com/embed/0gvBGmwhOLU");
            videoMap.Add("Ahri", "https://www.youtube.com/embed/hlalkAUkwqE");
            videoMap.Add("Akali", "https://www.youtube.com/embed/w8UjQ_hYfh4");
        }

        public String getURL(String id)
        {
            return videoMap[id];
        }
    }
}