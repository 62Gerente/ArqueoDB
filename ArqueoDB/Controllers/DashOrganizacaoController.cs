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

        // GET: /DashboardOrganizacao/

        public ActionResult Dashboard(int id = 0)
        {
            Organizacao organizacao = db.Organizacoes.Find(id);
            if (organizacao == null)
            {
                return HttpNotFound();
            }

            Imagem capa = db.Imagens.Find(organizacao.ImagemCapaID);
            Directoria dcapa = db.Directorias.Find(capa.DirectoriaID);

            Imagem perfil = db.Imagens.Find(organizacao.ImagemPerfilID);
            Directoria dperfil = db.Directorias.Find(perfil.DirectoriaID);

            ViewData["Capa"] = dcapa.Caminho + capa.Nome;
            ViewData["Perfil"] = dperfil.Caminho + perfil.Nome;

            ViewData["Dashboard"] = "Organizacao";            
            ViewData["Activo"] = "Dashboard";

            return View(organizacao);
        }

        public ActionResult Locais(int id = 0)
        {
            Organizacao organizacao = db.Organizacoes.Find(id);
            if (organizacao == null)
            {
                return HttpNotFound();
            }

            Imagem capa = db.Imagens.Find(organizacao.ImagemCapaID);
            Directoria dcapa = db.Directorias.Find(capa.DirectoriaID);

            Imagem perfil = db.Imagens.Find(organizacao.ImagemPerfilID);
            Directoria dperfil = db.Directorias.Find(perfil.DirectoriaID);

            ViewData["Capa"] = dcapa.Caminho + capa.Nome;
            ViewData["Perfil"] = dperfil.Caminho + perfil.Nome;

            ViewData["Dashboard"] = "Organizacao";
            ViewData["Activo"] = "Locais";

            ViewBag.Locais = (from l in db.Locais where l.OrganizacaoID == organizacao.OrganizacaoID select l).ToList(); 

            return View(organizacao);
        }

    }
}
