using ArqueoDB.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using ArqueoDB.DAL;
using System.Collections.Generic;

namespace ArqueoDB.Controllers
{
    public class DashLocalController : Controller
    {
        private EntidadesArqueoDB db = new EntidadesArqueoDB();

        public ActionResult Dashboard(int id = 1)
        {
            Local local = db.Locais.Find(id);
            if (local == null)
            {
                return HttpNotFound();
            }

            ViewData["Dashboard"] = "Local";
            ViewData["Activo"] = "Dashboard";

            return View(local);
        }

        public ActionResult Artefactos(int id, string sortOrder, string currentFilter, string searchString, string type, int? page)
        {
            Local local = db.Locais.Find(id);

            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentType = type;

            if (local == null)
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

            var artefactos = from a in db.Artefactos where a.LocalID == local.LocalID select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                artefactos = artefactos.Where(l => l.Nome.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "Nome":
                    artefactos = artefactos.OrderBy(l => l.Nome);
                    break;
                default:
                    break;

            }

            switch (type)
            {
                case "Públicos":
                    artefactos = artefactos.Where(l => l.Publico == true);
                    break;
                case "Ocultos":
                    artefactos = artefactos.Where(l => l.Publico == false);
                    break;
                default:
                    break;

            }

            int pageSize = 9;
            int pageNumber = (page ?? 1);
            ViewBag.Locais = artefactos.ToList().ToPagedList(pageNumber, pageSize);

            ViewData["Dashboard"] = "Organizacao";
            ViewData["Activo"] = "Locais";

            return View(local);
        }


        /* GET: Publicações */
        public ActionResult Publicacoes(int id = 0)
        {
            Local local = db.Locais.Find(id);
            if (local == null)
            {
                return HttpNotFound();
            }

            ViewData["Dashboard"] = "Local";
            ViewData["Activo"] = "Publicacoes";

            return View(local);
        }

        /* GET: Documentos */
        public ActionResult Documentos(int id, string sortOrder, string currentFilter, string searchString, string type, int? page)
        {
            Local local = db.Locais.Find(id);
            if (local == null)
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
            

            if (!String.IsNullOrEmpty(searchString))
            {
                local.Documentos.Where(l => l.Titulo.ToUpper().Contains(searchString.ToUpper()));                
            }

            IEnumerable<Documento> query = local.Documentos;
            
            switch (sortOrder)
            {
                case "Nome":
                     query = local.Documentos.OrderBy(doc => doc.Titulo);
                    break;
                case "Data":
                    query = local.Documentos.OrderBy(doc => doc.DataPublicacao);
                    break;
                case "Autor":
                    query = local.Documentos.OrderBy(doc => doc.Responsavel.Utilizador.Nome);
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
            ViewBag.Locais = query.ToList().ToPagedList(pageNumber, pageSize);

            ViewData["Dashboard"] = "Local";
            ViewData["Activo"] = "Documentos";

            return View(local);
        }
    }
}
