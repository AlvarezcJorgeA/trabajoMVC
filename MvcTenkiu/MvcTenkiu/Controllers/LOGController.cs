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
    public class LOGController : Controller
    {
        private RedSocialEntities db = new RedSocialEntities();

        //
        // GET: /LOG/

        public ActionResult Index()
        {
            return View(db.LOG.ToList());
        }

        //
        // GET: /LOG/Details/5

        public ActionResult Details(int id = 0)
        {
            LOG log = db.LOG.Find(id);
            if (log == null)
            {
                return HttpNotFound();
            }
            return View(log);
        }

        //
        // GET: /LOG/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /LOG/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LOG log)
        {
            if (ModelState.IsValid)
            {
                db.LOG.Add(log);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(log);
        }

        //
        // GET: /LOG/Edit/5

        public ActionResult Edit(int id = 0)
        {
            LOG log = db.LOG.Find(id);
            if (log == null)
            {
                return HttpNotFound();
            }
            return View(log);
        }

        //
        // POST: /LOG/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LOG log)
        {
            if (ModelState.IsValid)
            {
                db.Entry(log).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(log);
        }

        //
        // GET: /LOG/Delete/5

        public ActionResult Delete(int id = 0)
        {
            LOG log = db.LOG.Find(id);
            if (log == null)
            {
                return HttpNotFound();
            }
            return View(log);
        }

        //
        // POST: /LOG/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOG log = db.LOG.Find(id);
            db.LOG.Remove(log);
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