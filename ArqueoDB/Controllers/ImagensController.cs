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
    public class ImagensController : Controller
    {
        private EntidadesArqueoDB db = new EntidadesArqueoDB();

        //
        // GET: /Imagens/

        public ActionResult Index()
        {
            var imagens = db.Imagens.Include(i => i.Directoria);
            return View(imagens.ToList());
        }

        //
        // GET: /Imagens/Details/5

        public ActionResult Details(int id = 0)
        {
            Imagem imagem = db.Imagens.Find(id);
            if (imagem == null)
            {
                return HttpNotFound();
            }
            return View(imagem);
        }

        //
        // GET: /Imagens/Create

        public ActionResult Create()
        {
            ViewBag.DirectoriaID = new SelectList(db.Directorias, "DirectoriaID", "Caminho");
            return View();
        }

        //
        // POST: /Imagens/Create

        [HttpPost]
        public ActionResult Create(Imagem imagem)
        {
            if (ModelState.IsValid)
            {
                db.Imagens.Add(imagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DirectoriaID = new SelectList(db.Directorias, "DirectoriaID", "Caminho", imagem.DirectoriaID);
            return View(imagem);
        }

        //
        // GET: /Imagens/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Imagem imagem = db.Imagens.Find(id);
            if (imagem == null)
            {
                return HttpNotFound();
            }
            ViewBag.DirectoriaID = new SelectList(db.Directorias, "DirectoriaID", "Caminho", imagem.DirectoriaID);
            return View(imagem);
        }

        //
        // POST: /Imagens/Edit/5

        [HttpPost]
        public ActionResult Edit(Imagem imagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DirectoriaID = new SelectList(db.Directorias, "DirectoriaID", "Caminho", imagem.DirectoriaID);
            return View(imagem);
        }

        //
        // GET: /Imagens/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Imagem imagem = db.Imagens.Find(id);
            if (imagem == null)
            {
                return HttpNotFound();
            }
            return View(imagem);
        }

        //
        // POST: /Imagens/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Imagem imagem = db.Imagens.Find(id);
            db.Imagens.Remove(imagem);
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