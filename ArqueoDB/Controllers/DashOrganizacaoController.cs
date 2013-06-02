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
using System.Data.Entity.Validation;
using System.IO;
namespace ArqueoDB.Controllers
{
    public class DashOrganizacaoController : Controller
    {
        private EntidadesArqueoDB db = new EntidadesArqueoDB();

        // GET: /DashboardOrganizacao/Dashboard

        public ActionResult Dashboard(int id)
        {
            Utilizador sess = (Utilizador)Session["Utilizador"];

            if (sess == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Organizacao organizacao = db.Organizacoes.Find(id);
            if (organizacao == null)
            {
                return HttpNotFound();
            }

            Session["Organizacao"] = organizacao;
            Session["Utilizador"] = db.Utilizadores.Find(sess.UtilizadorID);

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
            List<Distrito> list = new List<Distrito>();
            foreach (Distrito d in db.Distritos) { list.Add(d); }
            ViewBag.Distritos = list;
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
            ViewBag.Locais = locais.ToList().ToPagedList(pageNumber, pageSize);

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

            IEnumerable<Profissional> query = org.Membros;

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

            List<Utilizador> listusers = new List<Utilizador>(); 
            foreach (Utilizador user in db.Utilizadores.Where(usr => !usr.Apagado))
            {
                listusers.Add(user);

            }
            ViewBag.users = listusers;
  
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
        public ActionResult Definicoes(Organizacao org)
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
            ViewData["Activo"] = "Estatísticas";

            return View(organizacao);
        }



        [HttpPost]
        public ActionResult AdicionarLocal(int idOrg)
        {
            Utilizador u = (Utilizador)(Session["Utilizador"]);
            string nome = Request["name"];

            HttpPostedFileBase file = Request.Files[0];
            string filename = System.IO.Path.GetFileName(Request.Files[0].FileName);
            var path = System.IO.Path.Combine(Server.MapPath("~/Images/Locais/"), filename);
            file.SaveAs(path);

            Imagem i = new Imagem
            {
                Apagada = false,
                AutorID = u.UtilizadorID,
                Comentarios = new List<Comentario>(),
                DataPublicacao = System.DateTime.Now,
                Descricao = nome,
                DirectoriaID = 3,
                Nome = filename,
                Publica = true
            };
            int distritoID = Convert.ToInt32(Request["distrito"]);
            string descricao = Request["descricao"];
            string isPublico = Request["isPublico"];
            string coordenadas = Request["coordenadas"];
            bool publico = (isPublico == "on") ? true : false;
            Local l = new Local {                                                                                
                Artefactos = new List<Artefacto>(),
                Coordenadas=coordenadas,
                Apagado= false,
                Comentarios = new List<Comentario>(),
                DataRegisto = System.DateTime.Now,
                Descricao = descricao,
                DistritoID = distritoID,
                Documentos = new List<Documento>(),
                Feeds = new List<Feed>(),
                Imagens = new List<Imagem>(),
                Nome = nome,
                OrganizacaoID = idOrg,
                Plantas = new List<Planta>(),
                Publicacoes = new List<Publicacao>(),
                Publico = publico,
                ResponsavelID = u.UtilizadorID,
                Seguidores = new List<Utilizador>()
                
            };
            db.Locais.Add(l);
            db.SaveChanges();

            Organizacao o = db.Organizacoes.Find(idOrg);
            o.Locais.Add(db.Locais.Where(x => x.Nome == nome).FirstOrDefault());
            db.SaveChanges();

            Local aux = db.Locais.Where(local => local.Nome == nome).FirstOrDefault();
            aux.Imagens.Add(i);
            db.SaveChanges();
            
            return RedirectToAction("Locais", "DashOrganizacao", new { id = idOrg });
        }

        [HttpPost]
        public ActionResult RequererOrgLocal(int idOrg)
        {
            string local = Request["local"];
            string comentario = Request["mensagem"];
            Utilizador u = (Utilizador)(Session["Utilizador"]);
            //Mandar mensagem ao responsavel
            return RedirectToAction("Locais", "DashOrganizacao", new { id = idOrg });
        }

        [HttpPost]
        public ActionResult AdicionarPublicacao(int idOrg)
        {
            string titulo = Request["titulo"];
            string descricao = Request["descricao"];
            string isPublico = Request["isPublico"];
            bool publico = (isPublico =="on") ? true : false;
            //Mandar mensagem ao responsavel
            Publicacao p = new Publicacao{
                Apagado = false,
                Comentarios = new List<Comentario>(),
                DataPublicacao = System.DateTime.Now,
                Descricao = descricao,
                Publico = publico,
                Titulo = titulo
                
            };
            Organizacao o = db.Organizacoes.Find(idOrg);
            o.Publicacoes.Add(p);
            db.SaveChanges();
            return RedirectToAction("Publicacoes", "DashOrganizacao", new { id = idOrg });
        }

        [HttpPost]
        public ActionResult AdicionarArtefacto(int idOrg)
        {
            string titulo = Request["titulo"];
            string descricao = Request["descricao"];
            string isPublico = Request["isPublico"];
            Utilizador u = (Utilizador)(Session["Utilizador"]);
            //Mandar mensagem ao responsavel
            return RedirectToAction("Locais", "DashOrganizacao", new { id = idOrg });
        }

        [HttpPost]
        public ActionResult NovaMensagem(int idOrg)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }
            string mensagem = Request["mensagem"];
            int idDest = Convert.ToInt32(Request["recept"]);
            Utilizador s = db.Utilizadores.Find(((Utilizador)(Session["Utilizador"])).UtilizadorID);
            string titulo = Request["assunto"];
            ////
            Utilizador r = db.Utilizadores.Find(idDest);
            Mensagem m = new Mensagem
            {
                DataEnvio = System.DateTime.Now,
                Corpo = mensagem,
                Assunto = titulo,
                ApagadoE = false,
                ApagadoR = false,
                Emissor = s,
                EmissorID = s.UtilizadorID,
                Lida = false,
                Receptor = r,
                ReceptorID = idDest 
            };
            //try
            //{
                r.MensagensRecebidas.Add(m);
                s.MensagensEnviadas.Add(m);
                db.SaveChanges();
            //}
            //catch (DbEntityValidationException e)
            //{
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage);
            //        }
            //    }
            //    throw;
            //}

            return RedirectToAction("Membros", "DashOrganizacao", new { id = idOrg });
        }

        [HttpPost]
        public ActionResult AdicionarDocumento(int idOrg)
        {
            string titulo = Request["titulo"];
            string descricao = Request["descricao"];
            string isPublico = Request["isPublico"];
            bool publico = (isPublico.Equals("on")) ? true : false;
            string filename = Path.GetFileName(Request.Files[0].FileName);
            Utilizador u = (Utilizador)(Session["Utilizador"]);
            Organizacao o = db.Organizacoes.Find(idOrg);
            var path = Path.Combine(Server.MapPath("~/Documentos/"), filename);
            HttpPostedFileBase file = Request.Files[0];
            file.SaveAs(path);
            
            Documento d = new Documento
            {
                Apagado= false,
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
            db.SaveChanges();
            //Mandar mensagem ao responsavel
            return RedirectToAction("Documentos", "DashOrganizacao", new { id = idOrg });
        }

        [HttpPost]
        public ActionResult AdicionarComentario(int idOrg)
        {
            string titulo = Request["titulo"];
            string descricao = Request["descricao"];
            string isPublico = Request["isPublico"];
            Utilizador u = (Utilizador)(Session["Utilizador"]);
            //Mandar mensagem ao responsavel
            return RedirectToAction("Locais", "DashOrganizacao", new { id = idOrg });
        }

        [HttpPost]
        public ActionResult AdicionarImagem(int idOrg)
        {
            string titulo = Request["titulo"];
            string descricao = Request["descricao"];
            string isPublico = Request["isPublico"];
            Utilizador u = (Utilizador)(Session["Utilizador"]);
            //Mandar mensagem ao responsavel
            return RedirectToAction("Locais", "DashOrganizacao", new { id = idOrg });
        }

        [HttpPost]
        public ActionResult AdicionarPlanta(int idOrg)
        {
            string titulo = Request["titulo"];
            string descricao = Request["descricao"];
            string isPublico = Request["isPublico"];
            Utilizador u = (Utilizador)(Session["Utilizador"]);
            //Mandar mensagem ao responsavel
            return RedirectToAction("Locais", "DashOrganizacao", new { id = idOrg });
        }

        [HttpPost]
        public ActionResult AdicionarMembro(int idOrg)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }
            string idMembro = Request["id"];
            Utilizador u = db.Utilizadores.Find(Convert.ToInt32(idMembro));
            Organizacao o = db.Organizacoes.Find(idOrg);
            o.Seguidores.Add(u);
            u.OrganizacoesSeguidas.Add(o);
            db.SaveChanges();
            return RedirectToAction("Membros", "DashOrganizacao", new { id = idOrg });
        }
    }
}