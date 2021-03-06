﻿using ArqueoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ArqueoDB.DAL;
using System.Data;

namespace ArqueoDB.Controllers
{
    public class DashArtefactoController : Controller
    {
        private EntidadesArqueoDB db = new EntidadesArqueoDB();

        // GET: /DashboardArtefactos/Dashboard

        public ActionResult Dashboard(int id)
        {
            Artefacto artefacto = db.Artefactos.Find(id);
            if (artefacto == null)
            {
                return HttpNotFound();
            }

            ViewData["Dashboard"] = "Artefacto";
            ViewData["Activo"] = "Dashboard";

            return View(artefacto);
        }

        public ActionResult Imagens(int id, string sortOrder, string currentFilter, string searchString, string type, int? page)
        {
            Artefacto artefacto = db.Artefactos.Find(id);

            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentType = type;

            if (artefacto == null)
            {
                return HttpNotFound();
            }

            if (Request.HttpMethod == "GET")
            {
                searchString = currentFilter;
            }
            else
            {
                page = 1;
            }

            ViewBag.CurrentFilter = searchString;

            var imagens = artefacto.Imagens.AsEnumerable<Imagem>();
            imagens = imagens.Where(i => i.Apagada == false);

            if (!String.IsNullOrEmpty(searchString))
            {
                imagens = imagens.Where(i => i.Nome.ToUpper().Contains(searchString.ToUpper()) ||
                                             i.Descricao.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "Data":
                    imagens = imagens.OrderBy(i => i.DataPublicacao);
                    break;
                default:
                    imagens = imagens.OrderBy(i => i.DataPublicacao);
                    break;

            }

            switch (type)
            {
                case "Públicas":
                    imagens = imagens.Where(i => i.Publica == true);
                    break;
                case "Ocultas":
                    imagens = imagens.Where(i => i.Publica == false);
                    break;
                default:
                    break;

            }

            int pageSize = 12;
            int pageNumber = (page ?? 1);
            ViewBag.Imagens = imagens.ToList().ToPagedList(pageNumber, pageSize);

            ViewData["Dashboard"] = "Artefacto";
            ViewData["Activo"] = "Imagens";

            return View(artefacto);
        }

        public ActionResult Definicoes(int id)
        {
            Artefacto artefacto = db.Artefactos.Find(id);
            if (artefacto == null)
            {
                return HttpNotFound();
            }

            ViewBag.ResponsavelID = new SelectList(artefacto.Organizacao.Membros, "ProfissionalID", "Utilizador.Nome", artefacto.ResponsavelID);
            ViewBag.LocalID = new SelectList(db.Distritos, "DistritoID", "Nome", artefacto.LocalID);

            ViewData["Dashboard"] = "Artefacto";
            ViewData["Activo"] = "Definições";

            return View(artefacto);


        }

        [HttpPost]
        public ActionResult Definicoes(Artefacto artefacto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artefacto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Dashboard", new { id = artefacto.ArtefactoID });
            }

            Artefacto art = db.Artefactos.Find(artefacto.ArtefactoID);
            ViewBag.ResponsavelID = new SelectList(artefacto.Organizacao.Membros, "ProfissionalID", "Utilizador.Nome", artefacto.ResponsavelID);
            ViewBag.LocalID = new SelectList(db.Locais, "LocalID", "Nome", artefacto.LocalID);

            ViewData["Dashboard"] = "Artefacto";
            ViewData["Activo"] = "Definições";

            return View(art);
        }

        public ActionResult Estatisticas(int id)
        {
            Artefacto art = db.Artefactos.Find(id);
            if (art == null)
            {
                return HttpNotFound();
            }

            ViewData["Dashboard"] = "Artefacto";
            ViewData["Activo"] = "Estatísticas";

            return View(art);
        }


        [HttpPost]
        public ActionResult AdicionarImagem(int id)
        {
            string descricao = Request["descricao"];
            string isPublico = Request["isPublico"];
            bool publico = (isPublico == "on") ? true : false;
            Utilizador u = (Utilizador)(Session["Utilizador"]);
            Artefacto a = db.Artefactos.Find(id);
            Organizacao o = db.Organizacoes.Find(a.OrganizacaoID);

            string filename = System.IO.Path.GetFileName(Request.Files[0].FileName);
            var path = System.IO.Path.Combine(Server.MapPath("~/Images/Artefactos/"), filename);
            HttpPostedFileBase file = Request.Files[0];
            file.SaveAs(path);

            Imagem i = new Imagem
            {
                Apagada = false,
                AutorID = u.UtilizadorID,
                Comentarios = new List<Comentario>(),
                DataPublicacao = System.DateTime.Now,
                Descricao = descricao,
                DirectoriaID = 4,
                Nome = filename,
                Publica = publico
            };
            a.Imagens.Add(i);
            db.SaveChanges();
            //Mandar mensagem ao responsavel
            return RedirectToAction("Imagens", "DashArtefacto", new { id = id });
        }
    }
}
