using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArqueoDB.Models;

namespace ArqueoDB.Controllers
{
    public class DistritosController : Controller
    {
        private EntidadesArqueoDB db = new EntidadesArqueoDB();

        //
        // GET: /Distritos/

        public ActionResult Index()
        {
            var distritos = db.Distritos.Include(d => d.Pais);
            return View(distritos.ToList());
        }

        //
        // GET: /Distritos/Details/5

        public ActionResult Details(int id = 0)
        {
            Distrito distrito = db.Distritos.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        //
        // GET: /Distritos/Create

        public ActionResult Create()
        {
            ViewBag.PaisID = new SelectList(db.Paises, "PaisID", "Nome");
            return View();
        }

        //
        // POST: /Distritos/Create

        [HttpPost]
        public ActionResult Create(Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                db.Distritos.Add(distrito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PaisID = new SelectList(db.Paises, "PaisID", "Nome", distrito.PaisID);
            return View(distrito);
        }

        //
        // GET: /Distritos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Distrito distrito = db.Distritos.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            ViewBag.PaisID = new SelectList(db.Paises, "PaisID", "Nome", distrito.PaisID);
            return View(distrito);
        }

        //
        // POST: /Distritos/Edit/5

        [HttpPost]
        public ActionResult Edit(Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distrito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PaisID = new SelectList(db.Paises, "PaisID", "Nome", distrito.PaisID);
            return View(distrito);
        }

        //
        // GET: /Distritos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Distrito distrito = db.Distritos.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        //
        // POST: /Distritos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Distrito distrito = db.Distritos.Find(id);
            db.Distritos.Remove(distrito);
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