using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;
using PagedList;
using ArqueoDB.DAL;
using ArqueoDB.Models;

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
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

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
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

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
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

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

        public ActionResult Publicar(int id)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Organizacao organizacao = db.Organizacoes.Find(id);
            organizacao.Publica = true;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult Ocultar(int id)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Organizacao organizacao = db.Organizacoes.Find(id);
            organizacao.Publica = false;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult Activar(int id)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Organizacao organizacao = db.Organizacoes.Find(id);
            organizacao.Activa = true;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult Desactivar(int id)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Organizacao organizacao = db.Organizacoes.Find(id);
            organizacao.Activa = false;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);

        }

        public ActionResult Seguir(int id, int seguir)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Utilizador utilizador = db.Utilizadores.Find(id);
            Organizacao orgSeguir = db.Organizacoes.Find(seguir);

            utilizador.OrganizacoesSeguidas.Add(orgSeguir);

            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult DeixarSeguir(int id, int seguir)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Utilizador utilizador = db.Utilizadores.Find(id);
            Organizacao orgSeguir = db.Organizacoes.Find(seguir);

            utilizador.OrganizacoesSeguidas.Remove(orgSeguir);
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }
        
    }
}