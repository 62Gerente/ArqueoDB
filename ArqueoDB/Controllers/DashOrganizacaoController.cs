using ArqueoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

            ViewBag.Locais = (from l in db.Locais where l.OrganizacaoID == organizacao.OrganizacaoID select l).ToList(); 

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

    }
}
