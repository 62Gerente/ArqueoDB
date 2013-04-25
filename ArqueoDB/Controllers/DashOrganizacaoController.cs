﻿using ArqueoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            
            var locais = from l in db.Locais where l.OrganizacaoID == organizacao.OrganizacaoID select l;

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

        public ActionResult Membros(int id = 1)
        {
            Organizacao organizacao = db.Organizacoes.Find(id);
            if (organizacao == null)
            {
                return HttpNotFound();
            }

            ViewData["Dashboard"] = "Organizacao";
            ViewData["Activo"] = "Membros";

            return View(organizacao);
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

    }
}
