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
    public class PlantasController : Controller
    {
        private EntidadesArqueoDB db = new EntidadesArqueoDB();

        //
        // GET: /Plantas/

        //public ActionResult Index()
        //{
        //    var plantas = db.Plantas.Include(p => p.Local).Include(p => p.Imagem).Include(p => p.Organizacao).Include(p => p.Responsavel);
        //    return View(plantas.ToList());
        //}

        ////
        //// GET: /Plantas/Details/5

        //public ActionResult Details(int id = 0)
        //{
        //    Planta planta = db.Plantas.Find(id);
        //    if (planta == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(planta);
        //}

        ////
        //// GET: /Plantas/Create

        //public ActionResult Create()
        //{
        //    ViewBag.LocalID = new SelectList(db.Locais, "LocalID", "Nome");
        //    ViewBag.ImagemID = new SelectList(db.Imagens, "ImagemID", "Nome");
        //    ViewBag.OrganizacaoID = new SelectList(db.Organizacoes, "OrganizacaoID", "Nome");
        //    ViewBag.ResponsavelID = new SelectList(db.Profissionais, "ProfissionalID", "ProfissionalID");
        //    return View();
        //}

        ////
        //// POST: /Plantas/Create

        //[HttpPost]
        //public ActionResult Create(Planta planta)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Plantas.Add(planta);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.LocalID = new SelectList(db.Locais, "LocalID", "Nome", planta.LocalID);
        //    ViewBag.ImagemID = new SelectList(db.Imagens, "ImagemID", "Nome", planta.ImagemID);
        //    ViewBag.OrganizacaoID = new SelectList(db.Organizacoes, "OrganizacaoID", "Nome", planta.OrganizacaoID);
        //    ViewBag.ResponsavelID = new SelectList(db.Profissionais, "ProfissionalID", "ProfissionalID", planta.ResponsavelID);
        //    return View(planta);
        //}

        ////
        //// GET: /Plantas/Edit/5

        //public ActionResult Edit(int id = 0)
        //{
        //    Planta planta = db.Plantas.Find(id);
        //    if (planta == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.LocalID = new SelectList(db.Locais, "LocalID", "Nome", planta.LocalID);
        //    ViewBag.ImagemID = new SelectList(db.Imagens, "ImagemID", "Nome", planta.ImagemID);
        //    ViewBag.OrganizacaoID = new SelectList(db.Organizacoes, "OrganizacaoID", "Nome", planta.OrganizacaoID);
        //    ViewBag.ResponsavelID = new SelectList(db.Profissionais, "ProfissionalID", "ProfissionalID", planta.ResponsavelID);
        //    return View(planta);
        //}

        ////
        //// POST: /Plantas/Edit/5

        //[HttpPost]
        //public ActionResult Edit(Planta planta)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(planta).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.LocalID = new SelectList(db.Locais, "LocalID", "Nome", planta.LocalID);
        //    ViewBag.ImagemID = new SelectList(db.Imagens, "ImagemID", "Nome", planta.ImagemID);
        //    ViewBag.OrganizacaoID = new SelectList(db.Organizacoes, "OrganizacaoID", "Nome", planta.OrganizacaoID);
        //    ViewBag.ResponsavelID = new SelectList(db.Profissionais, "ProfissionalID", "ProfissionalID", planta.ResponsavelID);
        //    return View(planta);
        //}

        ////
        //// GET: /Plantas/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    Planta planta = db.Plantas.Find(id);
        //    if (planta == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(planta);
        //}

        ////
        //// POST: /Plantas/Delete/5

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Planta planta = db.Plantas.Find(id);
        //    db.Plantas.Remove(planta);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}

        public ActionResult Publicar(int id)
        {
            Planta p = db.Plantas.Find(id);
            p.Publico = true;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult Ocultar(int id)
        {
            Planta p = db.Plantas.Find(id);
            p.Publico = false;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult Remover(int id)
        {
            Planta p = db.Plantas.Find(id);
            p.Apagado = true;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }
    }
}