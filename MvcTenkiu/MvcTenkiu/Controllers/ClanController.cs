using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTenkiu.Models;

namespace MvcTenkiu.Controllers
{
    public class ClanController : Controller
    {
        private RedSocialEntities db = new RedSocialEntities();

        //
        // GET: /Clan/

        public ActionResult Index()
        {
            return View(db.CLAN.ToList());
        }

        //
        // GET: /Clan/Details/5

        public ActionResult Details(long id = 0)
        {
            CLAN clan = db.CLAN.Find(id);
            if (clan == null)
            {
                return HttpNotFound();
            }
            return View(clan);
        }

        //
        // GET: /Clan/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Clan/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CLAN clan)
        {
            if (ModelState.IsValid)
            {
                clan.CL_FCREACION = DateTime.Now;
                if (clan.CL_PRIV == null) {
                    clan.CL_PRIV = false;
                }
                
                db.CLAN.Add(clan);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clan);
        }

        //
        // GET: /Clan/Edit/5

        public ActionResult Edit(long id = 0)
        {
            CLAN clan = db.CLAN.Find(id);
            if (clan == null)
            {
                return HttpNotFound();
            }
            return View(clan);
        }

        //
        // POST: /Clan/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CLAN clan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clan);
        }

        //
        // GET: /Clan/Delete/5

        public ActionResult Delete(long id = 0)
        {
            CLAN clan = db.CLAN.Find(id);
            if (clan == null)
            {
                return HttpNotFound();
            }
            return View(clan);
        }

        //
        // POST: /Clan/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CLAN clan = db.CLAN.Find(id);
            db.CLAN.Remove(clan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}