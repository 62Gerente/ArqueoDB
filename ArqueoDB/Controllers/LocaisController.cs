using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArqueoDB.Models;
using ArqueoDB.DAL;
using System.IO;

namespace ArqueoDB.Controllers
{
    public class LocaisController : Controller
    {
        private EntidadesArqueoDB db = new EntidadesArqueoDB();

        //
        // GET: /Locais/

        public ActionResult Index()
        {
            var locais = db.Locais.Include(l => l.Organizacao).Include(l => l.Responsavel).Include(l => l.Distrito);
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
            ViewBag.ResponsavelID = new SelectList(db.Profissionais, "ProfissionalID", "ProfissionalID");
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
            ViewBag.ResponsavelID = new SelectList(db.Profissionais, "ProfissionalID", "ProfissionalID", local.ResponsavelID);
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
            ViewBag.ResponsavelID = new SelectList(db.Profissionais, "ProfissionalID", "ProfissionalID", local.ResponsavelID);
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
            ViewBag.ResponsavelID = new SelectList(db.Profissionais, "ProfissionalID", "ProfissionalID", local.ResponsavelID);
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

        public ActionResult Publicar(int id)
        {
            Local local = db.Locais.Find(id);
            local.Publico = true;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult Ocultar(int id)
        {
            Local local = db.Locais.Find(id);
            local.Publico = false;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult Remover(int id)
        {
            Local local = db.Locais.Find(id);
            local.Apagado = true;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult Seguir(int id, int seguir)
        {

            Utilizador utilizador = db.Utilizadores.Find(id);
            Local locSeguir = db.Locais.Find(seguir);

            utilizador.LocaisSeguidos.Add(locSeguir);

            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult DeixarSeguir(int id, int seguir)
        {

            Utilizador utilizador = db.Utilizadores.Find(id);
            Local locSeguir = db.Locais.Find(seguir);

            utilizador.LocaisSeguidos.Remove(locSeguir);
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult Comentar(int id, int user, string comentario)
        {
            Local local = db.Locais.Find(id);

            Comentario comm = new Comentario
            {
                Apagado = false,
                AutorID = user,
                DataPublicacao = System.DateTime.Now,
                Texto = comentario
            };

            local.Comentarios.Add(comm);
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        [HttpPost]
        public ActionResult AddImagem(HttpPostedFileBase file)
        {
            int id = Convert.ToInt32(Request["id"]);
            int user = Convert.ToInt32(Request["user"]);
            var comentario = Request["comentario"];

            if (file != null && file.ContentLength > 0 && comentario !=null && !comentario.Equals(""))
            {
                 Local local = db.Locais.Find(id);

                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/Locais/"), fileName);
                file.SaveAs(path);

                Imagem imagem = new Imagem
                {
                    Apagada = false,
                    AutorID = user,
                    Comentarios = new List<Comentario>(),
                    DataPublicacao = System.DateTime.Now,
                    Descricao = comentario,
                    DirectoriaID = 3,
                    Nome = fileName,
                    Publica = true
                };

                local.Imagens.Add(imagem);
                db.SaveChanges();
            }
            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

    }
}