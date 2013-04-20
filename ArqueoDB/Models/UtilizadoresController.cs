using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArqueoDB.Models
{
    public class UtilizadoresController : Controller
    {
        private EntidadesArqueoDB db = new EntidadesArqueoDB();

        //
        // GET: /Utilizadores/

        public ActionResult Index()
        {
            var utilizadores = db.Utilizadores.Include(u => u.Distrito).Include(u => u.Titulo).Include(u => u.ImagemPerfil).Include(u => u.ImagemCapa);
            return View(utilizadores.ToList());
        }

        //
        // GET: /Utilizadores/Details/5

        public ActionResult Details(int id = 0)
        {
            Utilizador utilizador = db.Utilizadores.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        //
        // GET: /Utilizadores/Create

        public ActionResult Create()
        {
            ViewBag.DistritoID = new SelectList(db.Distritos, "DistritoID", "Nome");
            ViewBag.TituloID = new SelectList(db.Titulos, "TituloID", "Nome");
            ViewBag.ImagemPerfilID = new SelectList(db.Imagens, "ImagemID", "Nome");
            ViewBag.ImagemCapaID = new SelectList(db.Imagens, "ImagemID", "Nome");
            return View();
        }

        //
        // POST: /Utilizadores/Create

        [HttpPost]
        public ActionResult Create(Utilizador utilizador)
        {
            if (ModelState.IsValid)
            {
                utilizador.DataRegisto = System.DateTime.Now;
                db.Utilizadores.Add(utilizador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistritoID = new SelectList(db.Distritos, "DistritoID", "Nome", utilizador.DistritoID);
            ViewBag.TituloID = new SelectList(db.Titulos, "TituloID", "Nome", utilizador.TituloID);
            ViewBag.ImagemPerfilID = new SelectList(db.Imagens, "ImagemID", "Nome", utilizador.ImagemPerfilID);
            ViewBag.ImagemCapaID = new SelectList(db.Imagens, "ImagemID", "Nome", utilizador.ImagemCapaID);
            return View(utilizador);
        }

        //
        // GET: /Utilizadores/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Utilizador utilizador = db.Utilizadores.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistritoID = new SelectList(db.Distritos, "DistritoID", "Nome", utilizador.DistritoID);
            ViewBag.TituloID = new SelectList(db.Titulos, "TituloID", "Nome", utilizador.TituloID);
            ViewBag.ImagemPerfilID = new SelectList(db.Imagens, "ImagemID", "Nome", utilizador.ImagemPerfilID);
            ViewBag.ImagemCapaID = new SelectList(db.Imagens, "ImagemID", "Nome", utilizador.ImagemCapaID);
            return View(utilizador);
        }

        //
        // POST: /Utilizadores/Edit/5

        [HttpPost]
        public ActionResult Edit(Utilizador utilizador)
        {
            if (ModelState.IsValid)
            {
                utilizador.DataRegisto = System.DateTime.Now;
                db.Entry(utilizador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistritoID = new SelectList(db.Distritos, "DistritoID", "Nome", utilizador.DistritoID);
            ViewBag.TituloID = new SelectList(db.Titulos, "TituloID", "Nome", utilizador.TituloID);
            ViewBag.ImagemPerfilID = new SelectList(db.Imagens, "ImagemID", "Nome", utilizador.ImagemPerfilID);
            ViewBag.ImagemCapaID = new SelectList(db.Imagens, "ImagemID", "Nome", utilizador.ImagemCapaID);
            return View(utilizador);
        }

        //
        // GET: /Utilizadores/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Utilizador utilizador = db.Utilizadores.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        //
        // POST: /Utilizadores/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Utilizador utilizador = db.Utilizadores.Find(id);
            db.Utilizadores.Remove(utilizador);
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