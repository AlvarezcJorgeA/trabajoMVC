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
    public class VehiculoController : Controller
    {
        private RedSocialEntities db = new RedSocialEntities();

        //
        // GET: /Vehiculo/

        public ActionResult Index()
        {
            var vehiculo = db.VEHICULO.Include(v => v.CLAN).Include(v => v.DISPOSITIVO).Include(v => v.USUARIO);
            return View(vehiculo.ToList());
        }

        //
        // GET: /Vehiculo/Details/5

        public ActionResult Details(long id = 0)
        {
            VEHICULO vehiculo = db.VEHICULO.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        //
        // GET: /Vehiculo/Create

        public ActionResult Create()
        {
            ViewBag.CL_ID = new SelectList(db.CLAN, "CL_ID", "CL_NOMBRE");
            ViewBag.DP_ID = new SelectList(db.DISPOSITIVO, "DP_ID", "DP_MODELO");
            ViewBag.US_ID = new SelectList(db.USUARIO, "US_ID", "US_NOMBRE");
            return View();
        }

        //
        // POST: /Vehiculo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VEHICULO vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.VEHICULO.Add(vehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CL_ID = new SelectList(db.CLAN, "CL_ID", "CL_NOMBRE", vehiculo.CL_ID);
            ViewBag.DP_ID = new SelectList(db.DISPOSITIVO, "DP_ID", "DP_MODELO", vehiculo.DP_ID);
            ViewBag.US_ID = new SelectList(db.USUARIO, "US_ID", "US_NOMBRE", vehiculo.US_ID);
            return View(vehiculo);
        }

        //
        // GET: /Vehiculo/Edit/5

        public ActionResult Edit(long id = 0)
        {
            VEHICULO vehiculo = db.VEHICULO.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CL_ID = new SelectList(db.CLAN, "CL_ID", "CL_NOMBRE", vehiculo.CL_ID);
            ViewBag.DP_ID = new SelectList(db.DISPOSITIVO, "DP_ID", "DP_MODELO", vehiculo.DP_ID);
            ViewBag.US_ID = new SelectList(db.USUARIO, "US_ID", "US_NOMBRE", vehiculo.US_ID);
            return View(vehiculo);
        }

        //
        // POST: /Vehiculo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VEHICULO vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CL_ID = new SelectList(db.CLAN, "CL_ID", "CL_NOMBRE", vehiculo.CL_ID);
            ViewBag.DP_ID = new SelectList(db.DISPOSITIVO, "DP_ID", "DP_MODELO", vehiculo.DP_ID);
            ViewBag.US_ID = new SelectList(db.USUARIO, "US_ID", "US_NOMBRE", vehiculo.US_ID);
            return View(vehiculo);
        }

        //
        // GET: /Vehiculo/Delete/5

        public ActionResult Delete(long id = 0)
        {
            VEHICULO vehiculo = db.VEHICULO.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        //
        // POST: /Vehiculo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            VEHICULO vehiculo = db.VEHICULO.Find(id);
            db.VEHICULO.Remove(vehiculo);
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