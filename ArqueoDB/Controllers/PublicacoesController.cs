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
    public class PublicacoesController : Controller
    {
        private EntidadesArqueoDB db = new EntidadesArqueoDB();

        //
        // GET: /Publicacoes/

        public ActionResult Index()
        {
            return View(db.Publicacoes.ToList());
        }

        //
        // GET: /Publicacoes/Details/5

        public ActionResult Details(int id = 0)
        {
            Publicacao publicacao = db.Publicacoes.Find(id);
            if (publicacao == null)
            {
                return HttpNotFound();
            }
            return View(publicacao);
        }

        //
        // GET: /Publicacoes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Publicacoes/Create

        [HttpPost]
        public ActionResult Create(Publicacao publicacao)
        {
            if (ModelState.IsValid)
            {
                db.Publicacoes.Add(publicacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(publicacao);
        }

        //
        // GET: /Publicacoes/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Publicacao publicacao = db.Publicacoes.Find(id);
            if (publicacao == null)
            {
                return HttpNotFound();
            }
            return View(publicacao);
        }

        //
        // POST: /Publicacoes/Edit/5

        [HttpPost]
        public ActionResult Edit(Publicacao publicacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publicacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publicacao);
        }

        //
        // GET: /Publicacoes/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Publicacao publicacao = db.Publicacoes.Find(id);
            if (publicacao == null)
            {
                return HttpNotFound();
            }
            return View(publicacao);
        }

        //
        // POST: /Publicacoes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Publicacao publicacao = db.Publicacoes.Find(id);
            db.Publicacoes.Remove(publicacao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        //
        // GET: /Publicacoes/Ocultar

        public ActionResult Ocultar(int id)
        {
            Publicacao pub = db.Publicacoes.Find(id);
            pub.Publico = false;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        //
        // GET: /Publicacoes/Publicar

        public ActionResult Publicar(int id)
        {
            Publicacao pub = db.Publicacoes.Find(id);
            pub.Publico = true;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        //
        // GET: /Publicacoes/Remover

        public ActionResult Remover(int id)
        {
            Publicacao pub = db.Publicacoes.Find(id);
            pub.Apagado = true;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }
    }
}