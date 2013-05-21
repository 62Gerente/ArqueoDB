using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArqueoDB.Models;
using ArqueoDB.DAL;

namespace ArqueoDB.Controllers
{
    public class ProfissionaisController : Controller
    {
        private EntidadesArqueoDB db = new EntidadesArqueoDB();

        //
        // GET: /Profissionais/

        public ActionResult Index()
        {
            var profissionais = db.Profissionais.Include(p => p.Utilizador);
            return View(profissionais.ToList());
        }

        //
        // GET: /Profissionais/Details/5

        public ActionResult Details(int id = 0)
        {
            Profissional profissional = db.Profissionais.Find(id);
            if (profissional == null)
            {
                return HttpNotFound();
            }
            return View(profissional);
        }

        //
        // GET: /Profissionais/Create

        public ActionResult Create()
        {
            ViewBag.UtilizadorID = new SelectList(db.Utilizadores, "UtilizadorID", "NomeUtilizador");
            return View();
        }

        //
        // POST: /Profissionais/Create

        [HttpPost]
        public ActionResult Create(Profissional profissional)
        {
            if (ModelState.IsValid)
            {
                db.Profissionais.Add(profissional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UtilizadorID = new SelectList(db.Utilizadores, "UtilizadorID", "NomeUtilizador", profissional.UtilizadorID);
            return View(profissional);
        }

        //
        // GET: /Profissionais/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Profissional profissional = db.Profissionais.Find(id);
            if (profissional == null)
            {
                return HttpNotFound();
            }
            ViewBag.UtilizadorID = new SelectList(db.Utilizadores, "UtilizadorID", "NomeUtilizador", profissional.UtilizadorID);
            return View(profissional);
        }

        //
        // POST: /Profissionais/Edit/5

        [HttpPost]
        public ActionResult Edit(Profissional profissional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profissional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UtilizadorID = new SelectList(db.Utilizadores, "UtilizadorID", "NomeUtilizador", profissional.UtilizadorID);
            return View(profissional);
        }

        //
        // GET: /Profissionais/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Profissional profissional = db.Profissionais.Find(id);
            if (profissional == null)
            {
                return HttpNotFound();
            }
            return View(profissional);
        }

        //
        // POST: /Profissionais/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Profissional profissional = db.Profissionais.Find(id);
            db.Profissionais.Remove(profissional);
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