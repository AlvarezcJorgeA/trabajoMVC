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
    public class UsuarioController : Controller
    {
        private RedSocialEntities db = new RedSocialEntities();

        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            return View(db.USUARIO.ToList());
        }

        //
        // GET: /Usuario/Details/5

        [Authorize]
        public ActionResult Details(long id = 0)
        {
            USUARIO usuario = db.USUARIO.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // GET: /Usuario/Create

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Usuario/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(USUARIO usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.US_ESTADO = "Activo";
                usuario.US_FCREACION = DateTime.Now;
                usuario.US_ULTLOG = DateTime.Now;
                db.USUARIO.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        //
        // GET: /Usuario/Edit/5

        [Authorize]
        public ActionResult Edit(long id = 0)
        {
            USUARIO usuario = db.USUARIO.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /Usuario/Edit/5

        [HttpPost]
        [Authorize]
        public ActionResult Edit(USUARIO usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        //
        // GET: /Usuario/Delete/5

        [Authorize]
        public ActionResult Delete(long id = 0)
        {
            USUARIO usuario = db.USUARIO.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /Usuario/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult DeleteConfirmed(long id)
        {
            USUARIO usuario = db.USUARIO.Find(id);
            db.USUARIO.Remove(usuario);
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