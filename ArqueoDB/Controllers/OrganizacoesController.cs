using ArqueoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;
using PagedList;
using ArqueoDB.DAL;

namespace ArqueoDB.Controllers
{
    public class OrganizacoesController : Controller
    {
        private EntidadesArqueoDB db = new EntidadesArqueoDB();

        //
        // GET: /Organizacoes/

        public ActionResult Index()
        {
            var organizacoes = db.Organizacoes.Include(o => o.Distrito).Include(o => o.Responsavel).Include(o => o.ImagemPerfil).Include(o => o.ImagemCapa);
            return View(organizacoes.ToList());
        }

        //
        // GET: /Organizacoes/Details/5

        public ActionResult Details(int id = 0)
        {
            Organizacao organizacao = db.Organizacoes.Find(id);
            if (organizacao == null)
            {
                return HttpNotFound();
            }
            return View(organizacao);
        }

        //
        // GET: /Organizacoes/Create

        public ActionResult Create()
        {
            ViewBag.DistritoID = new SelectList(db.Distritos, "DistritoID", "Nome");
            ViewBag.ResponsavelID = new SelectList(db.Profissionais, "ProfissionalID", "ProfissionalID");
            ViewBag.ImagemPerfilID = new SelectList(db.Imagens, "ImagemID", "Nome");
            ViewBag.ImagemCapaID = new SelectList(db.Imagens, "ImagemID", "Nome");
            return View();
        }

        //
        // POST: /Organizacoes/Create

        [HttpPost]
        public ActionResult Create(Organizacao organizacao)
        {
            if (ModelState.IsValid)
            {
                db.Organizacoes.Add(organizacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistritoID = new SelectList(db.Distritos, "DistritoID", "Nome", organizacao.DistritoID);
            ViewBag.ResponsavelID = new SelectList(db.Profissionais, "ProfissionalID", "ProfissionalID", organizacao.ResponsavelID);
            ViewBag.ImagemPerfilID = new SelectList(db.Imagens, "ImagemID", "Nome", organizacao.ImagemPerfilID);
            ViewBag.ImagemCapaID = new SelectList(db.Imagens, "ImagemID", "Nome", organizacao.ImagemCapaID);
            return View(organizacao);
        }

        //
        // GET: /Organizacoes/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Organizacao organizacao = db.Organizacoes.Find(id);
            if (organizacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistritoID = new SelectList(db.Distritos, "DistritoID", "Nome", organizacao.DistritoID);
            ViewBag.ResponsavelID = new SelectList(db.Profissionais, "ProfissionalID", "ProfissionalID", organizacao.ResponsavelID);
            ViewBag.ImagemPerfilID = new SelectList(db.Imagens, "ImagemID", "Nome", organizacao.ImagemPerfilID);
            ViewBag.ImagemCapaID = new SelectList(db.Imagens, "ImagemID", "Nome", organizacao.ImagemCapaID);
            return View(organizacao);
        }

        //
        // POST: /Organizacoes/Edit/5

        [HttpPost]
        public ActionResult Edit(Organizacao organizacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organizacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistritoID = new SelectList(db.Distritos, "DistritoID", "Nome", organizacao.DistritoID);
            ViewBag.ResponsavelID = new SelectList(db.Profissionais, "ProfissionalID", "ProfissionalID", organizacao.ResponsavelID);
            ViewBag.ImagemPerfilID = new SelectList(db.Imagens, "ImagemID", "Nome", organizacao.ImagemPerfilID);
            ViewBag.ImagemCapaID = new SelectList(db.Imagens, "ImagemID", "Nome", organizacao.ImagemCapaID);
            return View(organizacao);
        }

        //
        // GET: /Organizacoes/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Organizacao organizacao = db.Organizacoes.Find(id);
            if (organizacao == null)
            {
                return HttpNotFound();
            }
            return View(organizacao);
        }

        //
        // POST: /Organizacoes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Organizacao organizacao = db.Organizacoes.Find(id);
            db.Organizacoes.Remove(organizacao);
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