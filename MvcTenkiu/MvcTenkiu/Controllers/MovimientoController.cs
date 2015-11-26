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
    public class MovimientoController : Controller
    {
        private RedSocialEntities db = new RedSocialEntities();

        //
        // GET: /Movimiento/

        public ActionResult Index()
        {
            var movimiento = db.MOVIMIENTO.Include(m => m.DISPOSITIVO);
            return View(movimiento.ToList());
        }

        //
        // GET: /Movimiento/Details/5

        public ActionResult Details(long id = 0)
        {
            MOVIMIENTO movimiento = db.MOVIMIENTO.Find(id);
            if (movimiento == null)
            {
                return HttpNotFound();
            }
            return View(movimiento);
        }

        //
        // GET: /Movimiento/Create

        public ActionResult Create()
        {
            ViewBag.DP_ID = new SelectList(db.DISPOSITIVO, "DP_ID", "DP_MODELO");
            return View();
        }

        //
        // POST: /Movimiento/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MOVIMIENTO movimiento)
        {
            if (ModelState.IsValid)
            {
                db.MOVIMIENTO.Add(movimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DP_ID = new SelectList(db.DISPOSITIVO, "DP_ID", "DP_MODELO", movimiento.DP_ID);
            return View(movimiento);
        }

        //
        // GET: /Movimiento/Edit/5

        public ActionResult Edit(long id = 0)
        {
            MOVIMIENTO movimiento = db.MOVIMIENTO.Find(id);
            if (movimiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.DP_ID = new SelectList(db.DISPOSITIVO, "DP_ID", "DP_MODELO", movimiento.DP_ID);
            return View(movimiento);
        }

        //
        // POST: /Movimiento/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MOVIMIENTO movimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DP_ID = new SelectList(db.DISPOSITIVO, "DP_ID", "DP_MODELO", movimiento.DP_ID);
            return View(movimiento);
        }

        //
        // GET: /Movimiento/Delete/5

        public ActionResult Delete(long id = 0)
        {
            MOVIMIENTO movimiento = db.MOVIMIENTO.Find(id);
            if (movimiento == null)
            {
                return HttpNotFound();
            }
            return View(movimiento);
        }

        //
        // POST: /Movimiento/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            MOVIMIENTO movimiento = db.MOVIMIENTO.Find(id);
            db.MOVIMIENTO.Remove(movimiento);
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