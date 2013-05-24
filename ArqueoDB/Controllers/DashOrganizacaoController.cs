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
    public class DashOrganizacaoController : Controller
    {
        private EntidadesArqueoDB db = new EntidadesArqueoDB();

        // GET: /DashboardOrganizacao/Dashboard

        public ActionResult Dashboard(int id)
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

        public ActionResult Locais(int id, string sortOrder, string currentFilter, string searchString, string type, int? page)
        {
            Organizacao organizacao = db.Organizacoes.Find(id);

            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentType = type;

            if (organizacao == null)
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
            
            var locais = organizacao.Locais.AsEnumerable<Local>();
            locais = locais.Where(l => l.Apagado == false);

            if (!String.IsNullOrEmpty(searchString))
            {
                locais = locais.Where(l => l.Nome.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "Nome":
                    locais = locais.OrderBy(l => l.Nome);
                    break;
                default:
                    break;

            }

            switch (type)
            {
                case "Públicos":
                    locais = locais.Where(l => l.Publico == true);
                    break;
                case "Ocultos":
                    locais = locais.Where(l => l.Publico == false);
                    break;
                default:
                    break;

            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            ViewBag.Locais = locais.ToList().ToPagedList(pageNumber,pageSize);

            ViewData["Dashboard"] = "Organizacao";
            ViewData["Activo"] = "Locais";
           
            return View(organizacao);
        }

        // GET: /DashboardOrganizacao/Membros
        
        public ActionResult Membros(int id, string sortOrder, string currentFilter, string searchString, string type, int? page)
        {
            Organizacao org = db.Organizacoes.Find(id);
            if (org == null)
            {
                return HttpNotFound();
            }

            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentType = type;

            if (Request.HttpMethod == "GET")
            {
                searchString = currentFilter;
            }
            else
            {
                page = 1;
            }

            ViewBag.CurrentFilter = searchString;

            IEnumerable<Profissional> query = org.Membros ;

            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(p => p.Utilizador.Nome.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "Nome":
                    query = query.OrderBy(m => m.Utilizador.NomeUtilizador);
                    break;                
                case "Email":
                    query = query.OrderBy(m => m.Utilizador.Email);
                    break;
                case "Distrito":
                    query = query.OrderBy(m => m.Utilizador.Distrito);
                    break;
                default:
                    break;
            }

            switch (type)
            {
                default:
                    break;
            }

            int pageSize = 12;
            int pageNumber = (page ?? 1);

            ViewBag.MembrosOrganizacao = query.ToList().ToPagedList(pageNumber, pageSize);
            ViewBag.pageSize = pageSize;
            ViewBag.page = pageNumber;

            ViewData["Dashboard"] = "Organizacao";
            ViewData["Activo"] = "Membros";

            return View(org);
        }

        // GET
        // Controlador para publicações

        public ActionResult Publicacoes(int id, string sortOrder, string currentFilter, string searchString, string type, int? page)
        {
            Organizacao org = db.Organizacoes.Find(id);
            if (org == null)
            {
                return HttpNotFound();
            }

            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentType = type;

            if (Request.HttpMethod == "GET")
            {
                searchString = currentFilter;
            }
            else
            {
                page = 1;
            }

            ViewBag.CurrentFilter = searchString;

            IEnumerable<Publicacao> query = org.Publicacoes.Where(p => p.Apagado == false).OrderBy(p => p.DataPublicacao).Reverse();

            if (!String.IsNullOrEmpty(searchString))
            {                
                query = query.Where(p => (p.Descricao.ToUpper().Contains(searchString.ToUpper()) || p.Titulo.ToUpper().Contains(searchString.ToUpper())));
            }

            switch (sortOrder)
            {
                case "DataPublicacao":
                    query = query.OrderBy(m => m.DataPublicacao);
                    break;                
                default:
                    break;
            }

            switch (type)
            {
                case "Públicas":
                    query = query.Where(p => p.Publico == true);
                    break;
                case "Ocultas":
                    query = query.Where(p => p.Publico == false);
                    break;
                default:
                    break;
            }

            int pageSize = 12;
            int pageNumber = (page ?? 1);

            ViewBag.PublicacoesOrganizacao = query.ToList().ToPagedList(pageNumber, pageSize);
            ViewBag.pageSize = pageSize;
            ViewBag.page = pageNumber;

            ViewData["Dashboard"] = "Organizacao";
            ViewData["Activo"] = "Publicações";

            return View(org);
        }        

         public ActionResult Definicoes(int id)
        {
            Organizacao organizacao = db.Organizacoes.Find(id);
            if (organizacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResponsavelID = new SelectList(organizacao.Membros, "ProfissionalID", "Utilizador.Nome", organizacao.ResponsavelID);
            ViewBag.DistritoID = new SelectList(db.Distritos, "DistritoID", "Nome", organizacao.DistritoID);
            ViewBag.ImagemPerfilID = new SelectList(db.Imagens, "ImagemID", "Nome", organizacao.ImagemPerfilID);
            ViewBag.ImagemCapaID = new SelectList(db.Imagens, "ImagemID", "Nome", organizacao.ImagemCapaID);

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
                return RedirectToAction("Dashboard", new { id = org.OrganizacaoID });
            }
            Organizacao organizacao = db.Organizacoes.Find(org.OrganizacaoID);
            ViewBag.ResponsavelID = new SelectList(organizacao.Membros, "ProfissionalID", "Utilizador.Nome", organizacao.ResponsavelID);
            ViewBag.DistritoID = new SelectList(db.Distritos, "DistritoID", "Nome", organizacao.DistritoID);
            ViewBag.ImagemPerfilID = new SelectList(db.Imagens, "ImagemID", "Nome", organizacao.ImagemPerfilID);
            ViewBag.ImagemCapaID = new SelectList(db.Imagens, "ImagemID", "Nome", organizacao.ImagemCapaID);

            ViewData["Dashboard"] = "Organizacao";
            ViewData["Activo"] = "Definições";
            return View(org);
        }
        // GET: /DashboardOrganizacao/Documentos
        public ActionResult Documentos(int id, string sortOrder, string currentFilter, string searchString, string type, int? page)
        {
            Organizacao org = db.Organizacoes.Find(id);
            if (org == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentType = type;

            if (Request.HttpMethod == "GET")
            {
                searchString = currentFilter;
            }
            else
            {
                page = 1;
            }

            ViewBag.CurrentFilter = searchString;

            IEnumerable<Documento> query = org.Documentos.Where(d => d.Apagado == false);

            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(l => l.Titulo.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "Nome":
                    query = query.OrderBy(doc => doc.Titulo);
                    break;
                case "Data":
                    query = query.OrderBy(doc => doc.DataPublicacao);
                    break;
                case "Autor":
                    query = query.OrderBy(doc => doc.Responsavel.Utilizador.Nome);
                    break;
                default:
                    break;
            }

            switch (type)
            {
                case "Públicos":
                    query = query.Where(doc => doc.Publico == true);
                    break;
                case "Ocultos":
                    query = query.Where(doc => doc.Publico == false);
                    break;
                default:
                    break;

            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            ViewBag.DocumentosOrganizacao = query.ToList().ToPagedList(pageNumber, pageSize);
            ViewBag.pageSize = pageSize;
            ViewBag.page = pageNumber;

            ViewData["Dashboard"] = "Organizacao";
            ViewData["Activo"] = "Documentos";

            return View(org);
        }

        //
        // GET: /DashOrganizacao/RemoverMembro
        /*
        public ActionResult Remover(int id, int membro_id)
        {
            Organizacao org = db.Organizacoes.Find(id);            
            org.Membros.Remove(
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }
         */

        public ActionResult Estatisticas(int id)
        {
            Organizacao organizacao = db.Organizacoes.Find(id);
            if (organizacao == null)
            {
                return HttpNotFound();
            }

            ViewData["Dashboard"] = "Organizacao";
            ViewData["Activo"] = "Estatisticas";

            return View(organizacao);
        }

    }
}
