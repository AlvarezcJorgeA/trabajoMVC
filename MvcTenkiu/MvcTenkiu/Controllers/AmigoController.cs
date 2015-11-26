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
    public class AmigoController : Controller
    {
        private RedSocialEntities db = new RedSocialEntities();

        //
        // GET: /Amigo/

        public ActionResult Index()
        {
            var amigo = db.AMIGO.Include(a => a.USUARIO);
            return View(amigo.ToList());
        }

        //
        // GET: /Amigo/Details/5

        public ActionResult Details(long id = 0)
        {
            AMIGO amigo = db.AMIGO.Find(id);
            if (amigo == null)
            {
                return HttpNotFound();
            }
            return View(amigo);
        }

        //
        // GET: /Amigo/Create

        public ActionResult Create()
        {
            ViewBag.US_ID = new SelectList(db.USUARIO, "US_ID", "US_NOMBRE");
            return View();
        }

        //
        // POST: /Amigo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AMIGO amigo)
        {
            if (ModelState.IsValid)
            {
                db.AMIGO.Add(amigo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.US_ID = new SelectList(db.USUARIO, "US_ID", "US_NOMBRE", amigo.US_ID);
            return View(amigo);
        }

        //
        // GET: /Amigo/Edit/5

        public ActionResult Edit(long id = 0)
        {
            AMIGO amigo = db.AMIGO.Find(id);
            if (amigo == null)
            {
                return HttpNotFound();
            }
            ViewBag.US_ID = new SelectList(db.USUARIO, "US_ID", "US_NOMBRE", amigo.US_ID);
            return View(amigo);
        }

        //
        // POST: /Amigo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AMIGO amigo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(amigo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.US_ID = new SelectList(db.USUARIO, "US_ID", "US_NOMBRE", amigo.US_ID);
            return View(amigo);
        }

        //
        // GET: /Amigo/Delete/5

        public ActionResult Delete(long id = 0)
        {
            AMIGO amigo = db.AMIGO.Find(id);
            if (amigo == null)
            {
                return HttpNotFound();
            }
            return View(amigo);
        }

        //
        // POST: /Amigo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            AMIGO amigo = db.AMIGO.Find(id);
            db.AMIGO.Remove(amigo);
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