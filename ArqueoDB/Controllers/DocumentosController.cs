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
    public class DocumentosController : Controller
    {
        private EntidadesArqueoDB db = new EntidadesArqueoDB();

        //
        // GET: /Documentos/Ocultar

        public ActionResult Ocultar(int id)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Documento doc = db.Documentos.Find(id);
            doc.Publico = false;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        //
        // GET: /Documentos/Publicar

        public ActionResult Publicar(int id)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Documento doc = db.Documentos.Find(id);
            doc.Publico = true;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        //
        // GET: /Documentos/Remover

        public ActionResult Remover(int id)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Documento doc = db.Documentos.Find(id);
            doc.Apagado = true;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        //
        // GET: /Documentos/Remover

        public ActionResult Transferir(int id)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Documento doc = db.Documentos.Find(id);
            
            return Redirect(doc.Directoria.Caminho+doc.NomeFicheiro);
        }


        //
        // GET: /Documentos/

        public ActionResult Index()
        {
            var documentos = db.Documentos.Include(d => d.Directoria).Include(d => d.Responsavel).Include(d => d.Organizacao);
            return View(documentos.ToList());
        }

        //
        // GET: /Documentos/Details/5

        public ActionResult Details(int id = 0)
        {
            Documento documento = db.Documentos.Find(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            return View(documento);
        }

        //
        // GET: /Documentos/Create

        public ActionResult Create()
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            ViewBag.DirectoriaID = new SelectList(db.Directorias, "DirectoriaID", "Caminho");
            ViewBag.ResponsavelID = new SelectList(db.Profissionais, "ProfissionalID", "ProfissionalID");
            ViewBag.OrganizacaoID = new SelectList(db.Organizacoes, "OrganizacaoID", "Nome");
            return View();
        }

        //
        // POST: /Documentos/Create

        [HttpPost]
        public ActionResult Create(Documento documento)
        {
            if (ModelState.IsValid)
            {
                db.Documentos.Add(documento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DirectoriaID = new SelectList(db.Directorias, "DirectoriaID", "Caminho", documento.DirectoriaID);
            ViewBag.ResponsavelID = new SelectList(db.Profissionais, "ProfissionalID", "ProfissionalID", documento.ResponsavelID);
            ViewBag.OrganizacaoID = new SelectList(db.Organizacoes, "OrganizacaoID", "Nome", documento.OrganizacaoID);
            return View(documento);
        }

        //
        // GET: /Documentos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Documento documento = db.Documentos.Find(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            ViewBag.DirectoriaID = new SelectList(db.Directorias, "DirectoriaID", "Caminho", documento.DirectoriaID);
            ViewBag.ResponsavelID = new SelectList(db.Profissionais, "ProfissionalID", "ProfissionalID", documento.ResponsavelID);
            ViewBag.OrganizacaoID = new SelectList(db.Organizacoes, "OrganizacaoID", "Nome", documento.OrganizacaoID);
            return View(documento);
        }

        //
        // POST: /Documentos/Edit/5

        [HttpPost]
        public ActionResult Edit(Documento documento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DirectoriaID = new SelectList(db.Directorias, "DirectoriaID", "Caminho", documento.DirectoriaID);
            ViewBag.ResponsavelID = new SelectList(db.Profissionais, "ProfissionalID", "ProfissionalID", documento.ResponsavelID);
            ViewBag.OrganizacaoID = new SelectList(db.Organizacoes, "OrganizacaoID", "Nome", documento.OrganizacaoID);
            return View(documento);
        }

        //
        // GET: /Documentos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Documento documento = db.Documentos.Find(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            return View(documento);
        }

        //
        // POST: /Documentos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Documento documento = db.Documentos.Find(id);
            db.Documentos.Remove(documento);
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