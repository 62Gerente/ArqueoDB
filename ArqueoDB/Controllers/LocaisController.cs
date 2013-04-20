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
    public class LocaisController : Controller
    {
        private EntidadesArqueoDB db = new EntidadesArqueoDB();

        //
        // GET: /Locais/

        public ActionResult Index()
        {
            var locais = db.Locais.Include(l => l.Organizacao).Include(l => l.Distrito);
            return View(locais.ToList());
        }

        //
        // GET: /Locais/Details/5

        public ActionResult Details(int id = 0)
        {
            Local local = db.Locais.Find(id);
            if (local == null)
            {
                return HttpNotFound();
            }
            return View(local);
        }

        //
        // GET: /Locais/Create

        public ActionResult Create()
        {
            ViewBag.OrganizacaoID = new SelectList(db.Organizacoes, "OrganizacaoID", "Nome");
            ViewBag.DistritoID = new SelectList(db.Distritos, "DistritoID", "Nome");
            return View();
        }

        //
        // POST: /Locais/Create

        [HttpPost]
        public ActionResult Create(Local local)
        {
            if (ModelState.IsValid)
            {
                db.Locais.Add(local);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrganizacaoID = new SelectList(db.Organizacoes, "OrganizacaoID", "Nome", local.OrganizacaoID);
            ViewBag.DistritoID = new SelectList(db.Distritos, "DistritoID", "Nome", local.DistritoID);
            return View(local);
        }

        //
        // GET: /Locais/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Local local = db.Locais.Find(id);
            if (local == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizacaoID = new SelectList(db.Organizacoes, "OrganizacaoID", "Nome", local.OrganizacaoID);
            ViewBag.DistritoID = new SelectList(db.Distritos, "DistritoID", "Nome", local.DistritoID);
            return View(local);
        }

        //
        // POST: /Locais/Edit/5

        [HttpPost]
        public ActionResult Edit(Local local)
        {
            if (ModelState.IsValid)
            {
                db.Entry(local).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganizacaoID = new SelectList(db.Organizacoes, "OrganizacaoID", "Nome", local.OrganizacaoID);
            ViewBag.DistritoID = new SelectList(db.Distritos, "DistritoID", "Nome", local.DistritoID);
            return View(local);
        }

        //
        // GET: /Locais/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Local local = db.Locais.Find(id);
            if (local == null)
            {
                return HttpNotFound();
            }
            return View(local);
        }

        //
        // POST: /Locais/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Local local = db.Locais.Find(id);
            db.Locais.Remove(local);
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