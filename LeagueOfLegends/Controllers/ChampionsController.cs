using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LeagueOfLegends.Models;

namespace LeagueOfLegends.Controllers
{
    public class ChampionsController : Controller
    {
        private LeagueOfLegendsStaticDataEntities1 db = new LeagueOfLegendsStaticDataEntities1();

        // GET: Champions
        public ActionResult Index()
        {
            return View(db.Champions.ToList());
        }

        // GET: Champions/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Champion champion = db.Champions.Find(id);
            if (champion == null)
            {
                return HttpNotFound();
            }
            return View(champion);
        }

        // GET: Champions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Champions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "champion_name,id")] Champion champion)
        {
            if (ModelState.IsValid)
            {
                db.Champions.Add(champion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(champion);
        }

        // GET: Champions/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Champion champion = db.Champions.Find(id);
            if (champion == null)
            {
                return HttpNotFound();
            }
            return View(champion);
        }

        // POST: Champions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "champion_name,id")] Champion champion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(champion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(champion);
        }

        // GET: Champions/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Champion champion = db.Champions.Find(id);
            if (champion == null)
            {
                return HttpNotFound();
            }
            return View(champion);
        }

        // POST: Champions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Champion champion = db.Champions.Find(id);
            db.Champions.Remove(champion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
