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
    public class DispositivoController : Controller
    {
        private RedSocialEntities db = new RedSocialEntities();

        //
        // GET: /Dispositivo/

        public ActionResult Index()
        {
            return View(db.DISPOSITIVO.ToList());
        }

        //
        // GET: /Dispositivo/Details/5

        public ActionResult Details(long id = 0)
        {
            DISPOSITIVO dispositivo = db.DISPOSITIVO.Find(id);
            if (dispositivo == null)
            {
                return HttpNotFound();
            }
            return View(dispositivo);
        }

        //
        // GET: /Dispositivo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Dispositivo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DISPOSITIVO dispositivo)
        {
            if (ModelState.IsValid)
            {
                dispositivo.DP_FCREACION = DateTime.Now;
                dispositivo.DP_STATUS = "Disponible";
                dispositivo.DP_PUNT = 0;
                db.DISPOSITIVO.Add(dispositivo);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dispositivo);
        }

        //
        // GET: /Dispositivo/Edit/5

        public ActionResult Edit(long id = 0)
        {
            DISPOSITIVO dispositivo = db.DISPOSITIVO.Find(id);
            if (dispositivo == null)
            {
                return HttpNotFound();
            }
            return View(dispositivo);
        }

        //
        // POST: /Dispositivo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DISPOSITIVO dispositivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dispositivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dispositivo);
        }

        //
        // GET: /Dispositivo/Delete/5

        public ActionResult Delete(long id = 0)
        {
            DISPOSITIVO dispositivo = db.DISPOSITIVO.Find(id);
            if (dispositivo == null)
            {
                return HttpNotFound();
            }
            return View(dispositivo);
        }

        //
        // POST: /Dispositivo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            DISPOSITIVO dispositivo = db.DISPOSITIVO.Find(id);
            db.DISPOSITIVO.Remove(dispositivo);
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