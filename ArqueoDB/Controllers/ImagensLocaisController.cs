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
    public class ImagensLocaisController : Controller
    {
        private EntidadesArqueoDB db = new EntidadesArqueoDB();

        //
        // GET: /ImagensLocais/

        public ActionResult Index()
        {
            var imagenslocais = db.ImagensLocais.Include(i => i.Imagem).Include(i => i.Local);
            return View(imagenslocais.ToList());
        }

        //
        // GET: /ImagensLocais/Details/5

        public ActionResult Details(int id = 0)
        {
            ImagemLocal imagemlocal = db.ImagensLocais.Find(id);
            if (imagemlocal == null)
            {
                return HttpNotFound();
            }
            return View(imagemlocal);
        }

        //
        // GET: /ImagensLocais/Create

        public ActionResult Create()
        {
            ViewBag.ImagemID = new SelectList(db.Imagens, "ImagemID", "Nome");
            ViewBag.LocalID = new SelectList(db.Locais, "LocalID", "Nome");
            return View();
        }

        //
        // POST: /ImagensLocais/Create

        [HttpPost]
        public ActionResult Create(ImagemLocal imagemlocal)
        {
            if (ModelState.IsValid)
            {
                db.ImagensLocais.Add(imagemlocal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ImagemID = new SelectList(db.Imagens, "ImagemID", "Nome", imagemlocal.ImagemID);
            ViewBag.LocalID = new SelectList(db.Locais, "LocalID", "Nome", imagemlocal.LocalID);
            return View(imagemlocal);
        }

        //
        // GET: /ImagensLocais/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ImagemLocal imagemlocal = db.ImagensLocais.Find(id);
            if (imagemlocal == null)
            {
                return HttpNotFound();
            }
            ViewBag.ImagemID = new SelectList(db.Imagens, "ImagemID", "Nome", imagemlocal.ImagemID);
            ViewBag.LocalID = new SelectList(db.Locais, "LocalID", "Nome", imagemlocal.LocalID);
            return View(imagemlocal);
        }

        //
        // POST: /ImagensLocais/Edit/5

        [HttpPost]
        public ActionResult Edit(ImagemLocal imagemlocal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagemlocal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ImagemID = new SelectList(db.Imagens, "ImagemID", "Nome", imagemlocal.ImagemID);
            ViewBag.LocalID = new SelectList(db.Locais, "LocalID", "Nome", imagemlocal.LocalID);
            return View(imagemlocal);
        }

        //
        // GET: /ImagensLocais/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ImagemLocal imagemlocal = db.ImagensLocais.Find(id);
            if (imagemlocal == null)
            {
                return HttpNotFound();
            }
            return View(imagemlocal);
        }

        //
        // POST: /ImagensLocais/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ImagemLocal imagemlocal = db.ImagensLocais.Find(id);
            db.ImagensLocais.Remove(imagemlocal);
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