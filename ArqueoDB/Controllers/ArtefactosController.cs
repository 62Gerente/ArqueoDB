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
    public class ArtefactosController : Controller
    {
        private EntidadesArqueoDB db = new EntidadesArqueoDB();

        //
        // GET: /Artefactos/

        public ActionResult Index()
        {
            var artefactos = db.Artefactos.Include(a => a.Local).Include(a => a.Organizacao).Include(a => a.Responsavel);
            return View(artefactos.ToList());
        }

        //
        // GET: /Artefactos/Details/5

        public ActionResult Details(int id = 0)
        {
            Artefacto artefacto = db.Artefactos.Find(id);
            if (artefacto == null)
            {
                return HttpNotFound();
            }
            return View(artefacto);
        }

        //
        // GET: /Artefactos/Create

        public ActionResult Create()
        {
            ViewBag.LocalID = new SelectList(db.Locais, "LocalID", "Nome");
            ViewBag.OrganizacaoID = new SelectList(db.Organizacoes, "OrganizacaoID", "Nome");
            ViewBag.ResponsavelID = new SelectList(db.Profissionais, "ProfissionalID", "ProfissionalID");
            return View();
        }

        //
        // POST: /Artefactos/Create

        [HttpPost]
        public ActionResult Create(Artefacto artefacto)
        {
            if (ModelState.IsValid)
            {
                db.Artefactos.Add(artefacto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocalID = new SelectList(db.Locais, "LocalID", "Nome", artefacto.LocalID);
            ViewBag.OrganizacaoID = new SelectList(db.Organizacoes, "OrganizacaoID", "Nome", artefacto.OrganizacaoID);
            ViewBag.ResponsavelID = new SelectList(db.Profissionais, "ProfissionalID", "ProfissionalID", artefacto.ResponsavelID);
            return View(artefacto);
        }

        //
        // GET: /Artefactos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Artefacto artefacto = db.Artefactos.Find(id);
            if (artefacto == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocalID = new SelectList(db.Locais, "LocalID", "Nome", artefacto.LocalID);
            ViewBag.OrganizacaoID = new SelectList(db.Organizacoes, "OrganizacaoID", "Nome", artefacto.OrganizacaoID);
            ViewBag.ResponsavelID = new SelectList(db.Profissionais, "ProfissionalID", "ProfissionalID", artefacto.ResponsavelID);
            return View(artefacto);
        }

        //
        // POST: /Artefactos/Edit/5

        [HttpPost]
        public ActionResult Edit(Artefacto artefacto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artefacto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocalID = new SelectList(db.Locais, "LocalID", "Nome", artefacto.LocalID);
            ViewBag.OrganizacaoID = new SelectList(db.Organizacoes, "OrganizacaoID", "Nome", artefacto.OrganizacaoID);
            ViewBag.ResponsavelID = new SelectList(db.Profissionais, "ProfissionalID", "ProfissionalID", artefacto.ResponsavelID);
            return View(artefacto);
        }

        //
        // GET: /Artefactos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Artefacto artefacto = db.Artefactos.Find(id);
            if (artefacto == null)
            {
                return HttpNotFound();
            }
            return View(artefacto);
        }

        //
        // POST: /Artefactos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Artefacto artefacto = db.Artefactos.Find(id);
            db.Artefactos.Remove(artefacto);
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
            Artefacto artefacto = db.Artefactos.Find(id);
            artefacto.Publico = true;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult Ocultar(int id)
        {
            Artefacto artefacto = db.Artefactos.Find(id);
            artefacto.Publico = false;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult Remover(int id)
        {
            Artefacto artefacto = db.Artefactos.Find(id);
            artefacto.Apagado = true;
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

            if (file != null && file.ContentLength > 0 && comentario != null && !comentario.Equals(""))
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