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
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

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
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

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
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

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
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Artefacto artefacto = db.Artefactos.Find(id);
            artefacto.Publico = true;
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

            Artefacto artefacto = db.Artefactos.Find(id);
            artefacto.Publico = false;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult Remover(int id)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Artefacto artefacto = db.Artefactos.Find(id);
            artefacto.Apagado = true;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult Comentar(int id, int user, string comentario)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Artefacto artefacto = db.Artefactos.Find(id);

            Comentario comm = new Comentario
            {
                Apagado = false,
                AutorID = user,
                DataPublicacao = System.DateTime.Now,
                Texto = comentario
            };

            artefacto.Comentarios.Add(comm);
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        [HttpPost]
        public ActionResult AddImagem(HttpPostedFileBase file)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            int id = Convert.ToInt32(Request["id"]);
            int user = Convert.ToInt32(Request["user"]);
            var comentario = Request["comentario"];

            if (file != null && file.ContentLength > 0 && comentario != null && !comentario.Equals(""))
            {
                Artefacto artefacto = db.Artefactos.Find(id);

                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/Artefactos/"), fileName);
                file.SaveAs(path);

                Imagem imagem = new Imagem
                {
                    Apagada = false,
                    AutorID = user,
                    Comentarios = new List<Comentario>(),
                    DataPublicacao = System.DateTime.Now,
                    Descricao = comentario,
                    DirectoriaID = 4,
                    Nome = fileName,
                    Publica = true
                };

                artefacto.Imagens.Add(imagem);
                db.SaveChanges();
            }
            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }



    }
}