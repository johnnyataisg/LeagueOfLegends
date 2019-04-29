using LeagueOfLegends.Models;
using LeagueOfLegends.Models.StaticDataModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LeagueOfLegends.Controllers
{
    public class AdminController : Controller
    {
        private static ChampionFull championFull;

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            String fileStream = new StreamReader(file.InputStream).ReadToEnd(); 
            championFull = JsonConvert.DeserializeObject<ChampionFull>(fileStream);

            return View(championFull);
        }

        public HttpResponseMessage CommitImport()
        {
            DAO dao = new DAO();
            dao.importChampionFullJSON(championFull);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent("Successful database import", Encoding.Unicode);
            return response;
        }
    }
}