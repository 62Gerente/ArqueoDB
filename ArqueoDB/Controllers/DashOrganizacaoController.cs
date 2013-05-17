using ArqueoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;

namespace ArqueoDB.Controllers
{
    public class DashOrganizacaoController : Controller
    {
        private EntidadesArqueoDB db = new EntidadesArqueoDB();

        // GET: /DashboardOrganizacao/Dashboard

        public ActionResult Dashboard(int id = 1)
        {
            Organizacao organizacao = db.Organizacoes.Find(id);
            if (organizacao == null)
            {               
                return HttpNotFound();
            }

            Session["Organizacao"] = organizacao;
            Session["Utilizador"] = organizacao.Responsavel.Utilizador;

            ViewData["Dashboard"] = "Organizacao";            
            ViewData["Activo"] = "Dashboard";

            return View(organizacao);
        }

        // GET: /DashboardOrganizacao/Locais

        public ActionResult Locais(int id = 1)
        {
            Organizacao organizacao = db.Organizacoes.Find(id);
            if (organizacao == null)
            {
                return HttpNotFound();
            }

            ViewData["Capa"] = organizacao.ImagemCapa.Directoria.Caminho + organizacao.ImagemCapa.Nome;
            ViewData["Perfil"] = organizacao.ImagemPerfil.Directoria.Caminho + organizacao.ImagemPerfil.Nome;

            ViewData["Dashboard"] = "Organizacao";
            ViewData["Activo"] = "Locais";
           
            return View(organizacao);
        }

        // GET: /DashboardOrganizacao/Membros

        public ActionResult Membros(int id = 1)
        {
            Organizacao organizacao = db.Organizacoes.Find(id);
            if (organizacao == null)
            {
                return HttpNotFound();
            }
            ViewData["Capa"] = organizacao.ImagemCapa.Directoria.Caminho + organizacao.ImagemCapa.Nome;
            ViewData["Perfil"] = organizacao.ImagemPerfil.Directoria.Caminho + organizacao.ImagemPerfil.Nome;

            ViewData["Dashboard"] = "Organizacao";
            ViewData["Activo"] = "Membros";

            return View(organizacao);
        }

        public ActionResult Definicoes(int id = 1)
        {
            Organizacao organizacao = db.Organizacoes.Find(id);
            if (organizacao == null)
            {
                return HttpNotFound();
            }

            ViewData["Dashboard"] = "Organizacao";
            ViewData["Activo"] = "Definições";

            return View(organizacao);


        }

        [HttpPost]
        public ActionResult Definicoes(Organizacao  org)
        {
            if (ModelState.IsValid)
            {
                db.Entry(org).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View(org);
        }

    }
}
