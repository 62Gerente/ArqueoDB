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
    public class DirectoriasController : Controller
    {
        private EntidadesArqueoDB db = new EntidadesArqueoDB();

        //
        // GET: /Directorias/

        public ActionResult Index()
        {
            return View(db.Directorias.ToList());
        }

        //
        // GET: /Directorias/Details/5

        public ActionResult Details(int id = 0)
        {
            Directoria directoria = db.Directorias.Find(id);
            if (directoria == null)
            {
                return HttpNotFound();
            }
            return View(directoria);
        }

        //
        // GET: /Directorias/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Directorias/Create

        [HttpPost]
        public ActionResult Create(Directoria directoria)
        {
            if (ModelState.IsValid)
            {
                db.Directorias.Add(directoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(directoria);
        }

        //
        // GET: /Directorias/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Directoria directoria = db.Directorias.Find(id);
            if (directoria == null)
            {
                return HttpNotFound();
            }
            return View(directoria);
        }

        //
        // POST: /Directorias/Edit/5

        [HttpPost]
        public ActionResult Edit(Directoria directoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(directoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(directoria);
        }

        //
        // GET: /Directorias/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Directoria directoria = db.Directorias.Find(id);
            if (directoria == null)
            {
                return HttpNotFound();
            }
            return View(directoria);
        }

        //
        // POST: /Directorias/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Directoria directoria = db.Directorias.Find(id);
            db.Directorias.Remove(directoria);
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