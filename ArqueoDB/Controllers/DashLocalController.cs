using ArqueoDB.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ArqueoDB.DAL;
using System.Collections.Generic;
using System.Data;

namespace ArqueoDB.Controllers
{
    public class DashLocalController : Controller
    {
        private EntidadesArqueoDB db = new EntidadesArqueoDB();

        public ActionResult Dashboard(int id)
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

            var artefactos = local.Artefactos.AsEnumerable<Artefacto>();
            artefactos = artefactos.Where(a => a.Apagado == false);

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
            ViewBag.Artefactos = artefactos.ToList().ToPagedList(pageNumber, pageSize);

            ViewData["Dashboard"] = "Local";
            ViewData["Activo"] = "Artefactos";

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

            IEnumerable<Documento> query = local.Documentos.Where(d => d.Apagado == false);

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

            ViewBag.DocumentosLocal = query.ToList().ToPagedList(pageNumber, pageSize);
            ViewBag.pageSize = pageSize;
            ViewBag.page = pageNumber;

            ViewData["Dashboard"] = "Local";
            ViewData["Activo"] = "Documentos";

            return View(local);
        }


        public ActionResult Definicoes(int id)
        {
            Local local = db.Locais.Find(id);
            if (local == null)
            {
                return HttpNotFound();
            }

            ViewBag.ResponsavelID = new SelectList(local.Organizacao.Membros, "ProfissionalID", "Utilizador.Nome", local.ResponsavelID);
            ViewBag.DistritoID = new SelectList(db.Distritos, "DistritoID", "Nome", local.DistritoID);

            ViewData["Dashboard"] = "Local";
            ViewData["Activo"] = "Definições";

            return View(local);
        }

        [HttpPost]
        public ActionResult Definicoes(Local local)
        {
            if (ModelState.IsValid)
            {
                db.Entry(local).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Dashboard", new { id = local.LocalID });
            }
            Local loc = db.Locais.Find(local.LocalID);
            ViewBag.ResponsavelID = new SelectList(local.Organizacao.Membros, "ProfissionalID", "Utilizador.Nome", local.ResponsavelID);
            ViewBag.DistritoID = new SelectList(db.Distritos, "DistritoID", "Nome", local.DistritoID);

            ViewData["Dashboard"] = "Local";
            ViewData["Activo"] = "Definições";

            return View(local);
        }

        public ActionResult Plantas(int id, string sortOrder, string currentFilter, string searchString, string type, int? page)
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

            var plantas = local.Plantas.AsEnumerable<Planta>();
            plantas = plantas.Where(i => i.Apagado == false);

            if (!String.IsNullOrEmpty(searchString))
            {
                plantas = plantas.Where(i => i.Imagem.Nome.ToUpper().Contains(searchString.ToUpper()) ||
                                             i.Imagem.Descricao.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "Data":
                    plantas = plantas.OrderBy(i => i.DataPublicacao);
                    break;
                default:
                    plantas = plantas.OrderBy(i => i.DataPublicacao);
                    break;

            }

            switch (type)
            {
                case "Públicas":
                    plantas = plantas.Where(i => i.Publico == true);
                    break;
                case "Ocultas":
                    plantas = plantas.Where(i => i.Publico == false);
                    break;
                default:
                    break;

            }

            int pageSize = 12;
            int pageNumber = (page ?? 1);
            ViewBag.Plantas = plantas.ToList().ToPagedList(pageNumber, pageSize);

            ViewData["Dashboard"] = "Local";
            ViewData["Activo"] = "Plantas";

            return View(local);
        }

        public ActionResult Imagens(int id, string sortOrder, string currentFilter, string searchString, string type, int? page)
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

            var imagens = local.Imagens.AsEnumerable<Imagem>();
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

            ViewData["Dashboard"] = "Local";
            ViewData["Activo"] = "Imagens";

            return View(local);
        }

        // GET
        // Controlador para publicações

        public ActionResult Publicacoes(int id, string sortOrder, string currentFilter, string searchString, string type, int? page)
        {
            Local loc = db.Locais.Find(id);
            if (loc == null)
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

            IEnumerable<Publicacao> query = loc.Publicacoes.Where(p => p.Apagado == false).OrderBy(p => p.DataPublicacao).Reverse();

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

            ViewBag.PublicacoesLocal = query.ToList().ToPagedList(pageNumber, pageSize);
            ViewBag.pageSize = pageSize;
            ViewBag.page = pageNumber;

            ViewData["Dashboard"] = "Local";
            ViewData["Activo"] = "Publicações";

            return View(loc);
        }

        public ActionResult Estatisticas(int id)
        {
            Local loc = db.Locais.Find(id);
            if (loc == null)
            {
                return HttpNotFound();
            }

            ViewData["Dashboard"] = "Local";
            ViewData["Activo"] = "Estatísticas";

            return View(loc);
        }

        [HttpPost]
        public ActionResult AdicionarDocumento(int id, int idOrg)
        {
            string titulo = Request["titulo"];
            string descricao = Request["descricao"];
            string isPublico = Request["isPublico"];
            string filename = System.IO.Path.GetFileName(Request.Files[0].FileName);
            bool publico = (isPublico.Equals("on")) ? true : false;
            Utilizador u = (Utilizador)(Session["Utilizador"]);
            Local l = db.Locais.Find(id);
            Organizacao o = db.Organizacoes.Find(idOrg);
            var path = System.IO.Path.Combine(Server.MapPath("~/Documentos/"), filename);
            HttpPostedFileBase file = Request.Files[0];
            file.SaveAs(path);

            Documento d = new Documento
            {
                Apagado = false,
                DataPublicacao = System.DateTime.Now,
                Descricao = descricao,
                DirectoriaID = 6,
                NomeFicheiro = filename,
                OrganizacaoID = idOrg,
                Publico = publico,
                ResponsavelID = u.UtilizadorID,
                Titulo = titulo
            };
            o.Documentos.Add(d);
            l.Documentos.Add(d);
            db.SaveChanges();
            //Mandar mensagem ao responsavel
            return RedirectToAction("Documentos", "DashLocal", new { id = id });
        }

        [HttpPost]
        public ActionResult AdicionarPublicacao(int id)
        {
            string titulo = Request["titulo"];
            string descricao = Request["descricao"];
            string isPublico = Request["isPublico"];
            bool publico = (isPublico == "on") ? true : false;
            //Mandar mensagem ao responsavel
            Publicacao p = new Publicacao
            {
                Apagado = false,
                Comentarios = new List<Comentario>(),
                DataPublicacao = System.DateTime.Now,
                Descricao = descricao,
                Publico = publico,
                Titulo = titulo
            };
            Local l = db.Locais.Find(id);
            Organizacao o = db.Organizacoes.Find(l.OrganizacaoID);
            l.Publicacoes.Add(p);
            o.Publicacoes.Add(p);
            db.SaveChanges();
            return RedirectToAction("Publicacoes", "DashLocal", new { id = id });
        }

        [HttpPost]
        public ActionResult AdicionarImagem(int id)
        {
            string descricao = Request["descricao"];
            string isPublico = Request["isPublico"];
            bool publico = (isPublico == "on") ? true : false;
            Utilizador u = (Utilizador)(Session["Utilizador"]);
            Local l = db.Locais.Find(id);
            Organizacao o = db.Organizacoes.Find(l.OrganizacaoID);

            string filename = System.IO.Path.GetFileName(Request.Files[0].FileName);
            var path = System.IO.Path.Combine(Server.MapPath("~/Images/Locais/"), filename);
            HttpPostedFileBase file = Request.Files[0];
            file.SaveAs(path);

            Imagem i = new Imagem
            {
                Apagada=false,
                AutorID=u.UtilizadorID,
                Comentarios=new List<Comentario>(),
                DataPublicacao= System.DateTime.Now,
                Descricao= descricao,
                DirectoriaID= 3,
                Nome=filename,
                Publica=publico
            };
            l.Imagens.Add(i);
            db.SaveChanges();
            //Mandar mensagem ao responsavel
            return RedirectToAction("Imagens", "DashLocal", new { id = id });
        }
    }
}
