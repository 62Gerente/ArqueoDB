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
    public class TitulosController : Controller
    {
        private EntidadesArqueoDB db = new EntidadesArqueoDB();

        //
        // GET: /Titulos/

        public ActionResult Index()
        {
            return View(db.Titulos.ToList());
        }

        //
        // GET: /Titulos/Details/5

        public ActionResult Details(int id = 0)
        {
            Titulo titulo = db.Titulos.Find(id);
            if (titulo == null)
            {
                return HttpNotFound();
            }
            return View(titulo);
        }

        //
        // GET: /Titulos/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Titulos/Create

        [HttpPost]
        public ActionResult Create(Titulo titulo)
        {
            if (ModelState.IsValid)
            {
                db.Titulos.Add(titulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(titulo);
        }

        //
        // GET: /Titulos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Titulo titulo = db.Titulos.Find(id);
            if (titulo == null)
            {
                return HttpNotFound();
            }
            return View(titulo);
        }

        //
        // POST: /Titulos/Edit/5

        [HttpPost]
        public ActionResult Edit(Titulo titulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(titulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(titulo);
        }

        //
        // GET: /Titulos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Titulo titulo = db.Titulos.Find(id);
            if (titulo == null)
            {
                return HttpNotFound();
            }
            return View(titulo);
        }

        //
        // POST: /Titulos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Titulo titulo = db.Titulos.Find(id);
            db.Titulos.Remove(titulo);
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