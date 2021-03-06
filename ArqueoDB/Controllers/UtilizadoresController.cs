﻿using System;
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
    public class UtilizadoresController : Controller
    {
        private EntidadesArqueoDB db = new EntidadesArqueoDB();

        //
        // GET: /Utilizadores/

        public ActionResult Index()
        {
            var utilizadores = db.Utilizadores.Include(u => u.Distrito).Include(u => u.Titulo).Include(u => u.ImagemPerfil).Include(u => u.ImagemCapa);
            return View(utilizadores.ToList());
        }

        //
        // GET: /Utilizadores/Details/5

        public ActionResult Details(int id = 0)
        {
            Utilizador utilizador = db.Utilizadores.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            List<Imagem> imagens = db.Imagens.Where(i => (((i.AutorID != null) && (i.AutorID == utilizador.UtilizadorID)  ) && 
                                                                        (i.ImagemID != utilizador.ImagemCapaID) &&
                                                                        (i.ImagemID != utilizador.ImagemPerfilID) &&
                                                                        (i.Apagada == false) && (i.Publica == true))).ToList();
            ViewBag.Imagens = imagens;

            return View(utilizador);
        }

        //
        // GET: /Utilizadores/Create

        public ActionResult Create()
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            ViewBag.DistritoID = new SelectList(db.Distritos, "DistritoID", "Nome");
            ViewBag.TituloID = new SelectList(db.Titulos, "TituloID", "Nome");
            ViewBag.ImagemPerfilID = new SelectList(db.Imagens, "ImagemID", "Nome");
            ViewBag.ImagemCapaID = new SelectList(db.Imagens, "ImagemID", "Nome");
            return View();
        }

        //
        // POST: /Utilizadores/Create

        [HttpPost]
        public ActionResult Create(Utilizador utilizador)
        {
            if (ModelState.IsValid)
            {
                db.Utilizadores.Add(utilizador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistritoID = new SelectList(db.Distritos, "DistritoID", "Nome", utilizador.DistritoID);
            ViewBag.TituloID = new SelectList(db.Titulos, "TituloID", "Nome", utilizador.TituloID);
            ViewBag.ImagemPerfilID = new SelectList(db.Imagens, "ImagemID", "Nome", utilizador.ImagemPerfilID);
            ViewBag.ImagemCapaID = new SelectList(db.Imagens, "ImagemID", "Nome", utilizador.ImagemCapaID);
            return View(utilizador);
        }

        //
        // GET: /Utilizadores/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Utilizador utilizador = db.Utilizadores.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistritoID = new SelectList(db.Distritos, "DistritoID", "Nome", utilizador.DistritoID);
            ViewBag.TituloID = new SelectList(db.Titulos, "TituloID", "Nome", utilizador.TituloID);
            ViewBag.ImagemPerfilID = new SelectList(db.Imagens, "ImagemID", "Nome", utilizador.ImagemPerfilID);
            ViewBag.ImagemCapaID = new SelectList(db.Imagens, "ImagemID", "Nome", utilizador.ImagemCapaID);
            return View(utilizador);
        }

        //
        // POST: /Utilizadores/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, String Nome, String NomeUtilizador, String Email, String Telemovel, String Distrito, String DataNascimento, int Sexo, String Descricao, String Password, String Confirm, String Facebook, String Google, String Twitter, String Linkedin)
        {
            Utilizador utilizador = db.Utilizadores.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }

            if (Password == Confirm)
            {

                utilizador.Nome = Nome;
                utilizador.NomeUtilizador = NomeUtilizador;
                utilizador.Email = Email;
                utilizador.Telemovel = Telemovel;
                utilizador.Sexo = Sexo;
                utilizador.Descricao = Descricao;
                utilizador.Password = Password;
                utilizador.Facebook = Facebook;
                utilizador.Google = Google;
                utilizador.Twitter = Twitter;
                utilizador.Linkedin = Linkedin;

                db.SaveChanges();
            }


            
            ViewBag.DistritoID = new SelectList(db.Distritos, "DistritoID", "Nome", utilizador.DistritoID);
            ViewBag.TituloID = new SelectList(db.Titulos, "TituloID", "Nome", utilizador.TituloID);
            ViewBag.ImagemPerfilID = new SelectList(db.Imagens, "ImagemID", "Nome", utilizador.ImagemPerfilID);
            ViewBag.ImagemCapaID = new SelectList(db.Imagens, "ImagemID", "Nome", utilizador.ImagemCapaID);
            return RedirectToAction("Perfil", "Utilizadores", new { id });
        }

        //
        // GET: /Utilizadores/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Utilizador utilizador = db.Utilizadores.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        //
        // POST: /Utilizadores/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Utilizador utilizador = db.Utilizadores.Find(id);
            db.Utilizadores.Remove(utilizador);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Seguir(int id, int seguir){
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }
            Utilizador utilizador = db.Utilizadores.Find(id);
            Utilizador utilizadorSeguir = db.Utilizadores.Find(seguir);

            utilizador.UtilizadoresSeguidos.Add(utilizadorSeguir);

            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult DeixarSeguir(int id, int seguir)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Utilizador utilizador = db.Utilizadores.Find(id);
            Utilizador utilizadorSeguir = db.Utilizadores.Find(seguir);

            utilizador.UtilizadoresSeguidos.Remove(utilizadorSeguir);
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult Comentar(int id, int user, string comentario) {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Utilizador utilizador = db.Utilizadores.Find(id);

            Comentario comm = new Comentario
            {
                Apagado = false,
                AutorID = user, 
                DataPublicacao = System.DateTime.Now,
                Texto = comentario
            };

            utilizador.Comentarios.Add(comm);
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult Publicar(int id, string titulo, string descr) {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Utilizador user = db.Utilizadores.Find(id);

            Publicacao pub = new Publicacao
            {
                Apagado = false,
                Publico = true,
                DataPublicacao = System.DateTime.Now,
                Titulo = titulo,
                Descricao = descr
            };

            user.Publicacoes.Add(pub);
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);

        
        }

        public ActionResult Perfil()
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Utilizador sessao = (Utilizador) Session["Utilizador"];

            if (sessao == null)
            {
                return HttpNotFound();
            }

            Utilizador utilizador = db.Utilizadores.Find(sessao.UtilizadorID);
            
            if (utilizador == null)
            {
                return HttpNotFound();
            }

            Session["Login"] = true;
            Session["Utilizador"] = utilizador;

            List<Imagem> imagens = db.Imagens.Where(i => (((i.AutorID != null) && (i.AutorID == utilizador.UtilizadorID)) &&
                                                                        (i.ImagemID != utilizador.ImagemCapaID) &&
                                                                        (i.ImagemID != utilizador.ImagemPerfilID) &&
                                                                        (i.Apagada == false) && (i.Publica == true))).ToList();
            ViewBag.Imagens = imagens;
            Dictionary<Publicacao, String> pubdetails = new Dictionary<Publicacao, String>();
            Dictionary<Publicacao,String> publicacoes = new Dictionary<Publicacao, String>();
            List<Publicacao> listapub = new List<Publicacao>();
            foreach (Organizacao org in utilizador.OrganizacoesSeguidas.Where(o => o.Publica && !o.Apagada ))
            {
                listapub.AddRange(org.Publicacoes);
                foreach (Publicacao pbl in org.Publicacoes.Where(p => p.Publico && !p.Apagado))
                {
                    publicacoes.Add(pbl, org.Nome);
                    pubdetails.Add(pbl, org.ImagemPerfil.Directoria.Caminho + org.ImagemPerfil.Nome);

                }
            
            }
            foreach (Utilizador user in utilizador.UtilizadoresSeguidos.Where(u => !u.Apagado))
            {
                listapub.AddRange(user.Publicacoes);
                foreach (Publicacao pbl in user.Publicacoes.Where(p => p.Publico && !p.Apagado))
                {
                    publicacoes.Add( pbl, user.Nome);
                    pubdetails.Add(pbl, user.ImagemPerfil.Directoria.Caminho + user.ImagemPerfil.Nome);
                }

            }
            foreach (Local loc in utilizador.LocaisSeguidos.Where(l => l.Publico && !l.Apagado))
            {
                listapub.AddRange(loc.Publicacoes);
                foreach (Publicacao pbl in loc.Publicacoes.Where(p => p.Publico && !p.Apagado))
                {
                    publicacoes.Add(pbl, loc.Nome);
                    pubdetails.Add(pbl, loc.Imagens.First().Directoria.Caminho + loc.Imagens.First().Nome);
                }

            }
            listapub = listapub.OrderByDescending(p => p.DataPublicacao.ToShortDateString()).ThenByDescending(p => p.DataPublicacao.ToShortTimeString()).ToList();
            ViewBag.publicacoes = publicacoes;
            ViewBag.pubdetails = pubdetails;
            ViewBag.listapub = listapub;
            return View(utilizador);
        }



        public ActionResult DeleteOrg(int id,int idorg)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Utilizador utilizador = db.Utilizadores.Find(id);
            Organizacao org = db.Organizacoes.Find(idorg);
            if (utilizador == null)
            {
                return HttpNotFound();
            }

            utilizador.OrganizacoesSeguidas.Remove(org);
            db.SaveChanges();

            return RedirectToAction("Edit", "Utilizadores", new { id });


        }

        public ActionResult DeleteLoc(int id, int idloc)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Utilizador utilizador = db.Utilizadores.Find(id);
            Local l = db.Locais.Find(idloc);
            if (utilizador == null)
            {
                return HttpNotFound();
            }

            utilizador.LocaisSeguidos.Remove(l);
            db.SaveChanges();

            return RedirectToAction("Edit", "Utilizadores", new { id });


        }


        public ActionResult DeleteUser(int id, int idusr)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Utilizador utilizador = db.Utilizadores.Find(id);
            Utilizador u = db.Utilizadores.Find(idusr);
            if (utilizador == null)
            {
                return HttpNotFound();
            }

            utilizador.UtilizadoresSeguidos.Remove(u);
            db.SaveChanges();

            return RedirectToAction("Edit", "Utilizadores", new { id });


        }

        public ActionResult Inbox(int id) {

            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Utilizador u = db.Utilizadores.Find(id);
            List<Utilizador> listusers = new List<Utilizador>();
            if (u == null)
            {
                return HttpNotFound();
            }


            foreach (Utilizador user in db.Utilizadores.Where(usr => !usr.Apagado))
            {
                listusers.Add(user);

            }

            ViewBag.listausers = listusers;
            return View(u);
        
        }


        public ActionResult Outbox(int id)
        {

            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Utilizador u = db.Utilizadores.Find(id);


            return View(u);

        }



        [HttpPost]
        public ActionResult Inbox(int id, int recept, String assunto, String corpo)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Utilizador s = db.Utilizadores.Find(id);
            Utilizador r = db.Utilizadores.Find(recept);
            List<Utilizador> listusers = new List<Utilizador>();
            Mensagem m = new Mensagem
            {
                DataEnvio = System.DateTime.Now,
                Corpo = corpo,
                Assunto = assunto,
                ApagadoE = false,
                ApagadoR = false,
                Emissor = s,
                EmissorID = s.UtilizadorID,
                Lida = false,
                Receptor = r,
                ReceptorID = r.UtilizadorID
            };

            r.MensagensRecebidas.Add(m);
            s.MensagensEnviadas.Add(m);
            db.SaveChanges();

            foreach (Utilizador user in db.Utilizadores.Where(usr => !usr.Apagado))
            {
                listusers.Add(user);

            }
         
            ViewBag.listausers = listusers;

            return View(s);
        }

        public ActionResult MarkAllRead(int id) {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }


            Utilizador u = db.Utilizadores.Find(id);

            foreach (Mensagem m in u.MensagensRecebidas) {
                m.Lida = true;
            }
            db.SaveChanges();
 
            return RedirectToAction("Inbox", "Utilizadores", new { id });
        }


        public ActionResult DeleteAllMsgR(int id)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Utilizador u = db.Utilizadores.Find(id);

            foreach (Mensagem m in u.MensagensRecebidas)
            {
                m.ApagadoR = true;
                m.Lida = true;

            }
            db.SaveChanges();
            return RedirectToAction("Inbox", "Utilizadores", new { id });
        }

        public ActionResult DeleteAllMsgE(int id)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Utilizador u = db.Utilizadores.Find(id);

            foreach (Mensagem m in u.MensagensEnviadas)
            {
                m.ApagadoE = true;

            }
            db.SaveChanges();
            return RedirectToAction("Outbox", "Utilizadores", new { id });
        }


        public ActionResult DeleteMsgR(int id, int msgid)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Utilizador u = db.Utilizadores.Find(id);


            foreach (Mensagem m in u.MensagensRecebidas.Where(p => p.MensagemID == msgid)) {
                m.ApagadoR = true;
                m.Lida = true;
            }
            db.SaveChanges();

            return RedirectToAction("Inbox", "Utilizadores", new { id });
        }

        public ActionResult DeleteMsgE(int id, int msgid)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Utilizador u = db.Utilizadores.Find(id);


            foreach (Mensagem m in u.MensagensEnviadas.Where(p => p.MensagemID == msgid))
            {
                m.ApagadoE = true;
            }
            db.SaveChanges();

            return RedirectToAction("Outbox", "Utilizadores", new { id });
        }

        public ActionResult MessageSent(int id, int msgid)
        {

            Utilizador user = db.Utilizadores.Find(id);
            Mensagem m = user.MensagensEnviadas.Where(p => p.MensagemID == msgid).FirstOrDefault();

            db.SaveChanges();



            ViewBag.msg = m;
            return View(user);
        }


        public ActionResult Message(int id, int msgid){
        
            Utilizador user = db.Utilizadores.Find(id);
            Mensagem m = user.MensagensRecebidas.Where(p => p.MensagemID == msgid).FirstOrDefault();

            m.Lida = true;
            db.SaveChanges();



            ViewBag.msg = m;
            return View(user);
        }


        [HttpPost]
        public ActionResult Message(int id, int msgid, int recept , String assunto, String corpo)
        {

            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Utilizador s = db.Utilizadores.Find(id);
            Utilizador r = db.Utilizadores.Find(recept);
            List<Utilizador> listusers = new List<Utilizador>();
            Mensagem m = new Mensagem
            {
                DataEnvio = System.DateTime.Now,
                Corpo = corpo,
                Assunto = assunto,
                ApagadoE = false,
                ApagadoR = false,
                Emissor = s,
                EmissorID = s.UtilizadorID,
                Lida = false,
                Receptor = r,
                ReceptorID = r.UtilizadorID
            };

            r.MensagensRecebidas.Add(m);
            s.MensagensEnviadas.Add(m);
            db.SaveChanges();
            ViewBag.msg = m;
            return RedirectToAction("Inbox", "Utilizadores", new { id });
        }



        [HttpPost]
        public ActionResult LoginHome()
        {
            string username = Request["name"];
            string password = Request["password"];

            Utilizador user = db.Utilizadores.Where(u => u.NomeUtilizador.Equals(username)).FirstOrDefault();

            if (user != null && user.Password.Equals(password))
            {
                Session["Utilizador"] = user;
                return RedirectToAction("Perfil", "Utilizadores");
            }
            Session["Login"] = false;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {
            ViewBag.Erro = null;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name)
        {
            string password = Request["password"];

            Utilizador user = db.Utilizadores.Where(u => u.NomeUtilizador.Equals(name)).FirstOrDefault();

            if (user != null && user.Password.Equals(password))
            {
                ViewBag.Erro = null;
                Session["Utilizador"] = user;
                return RedirectToAction("Perfil", "Utilizadores");
            }
            Session["Login"] = null;
            ViewBag.Erro = true;
            return View();
        }

        public ActionResult Logout()
        {
            Session["Utilizador"] = null;
            Session["Login"] = null;
            return RedirectToAction("Index", "Home");

        }

        public ActionResult Registo() {
            ViewBag.DistritoID = new SelectList(db.Distritos, "DistritoID", "Nome");
            ViewBag.TituloID = new SelectList(db.Titulos, "TituloID", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Registo(HttpPostedFileBase uploadfile,Utilizador utilizador)
        {
            HttpPostedFileBase file = uploadfile;

            ViewBag.Erro = null;
            string sexo = Request["sexo"];
            string passconf = Request["passconf"];

            if (file != null && file.ContentLength > 0 && passconf!=null && passconf.Equals(utilizador.Password)) {

                if (sexo != null && !sexo.Equals("")) {
                    if (sexo.Equals("Masculino")) {
                        utilizador.Sexo = 1;
                    }
                    else if (sexo.Equals("Feminino")) {
                        utilizador.Sexo = 2;
                    }
                }

                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/Utilizadores/"), fileName);
                file.SaveAs(path);

                Imagem imagem = new Imagem
                {
                    Apagada = false,
                    AutorID = 1,
                    Comentarios = new List<Comentario>(),
                    DataPublicacao = System.DateTime.Now,
                    Descricao = "Imagem de perfil",
                    DirectoriaID = 2,
                    Nome = fileName,
                    Publica = true
                };
                db.Imagens.Add(imagem);
                db.SaveChanges();

                utilizador.ImagemPerfil = imagem;
                utilizador.ImagemCapa = imagem;

                utilizador.Apagado = false;
                utilizador.Banido = false;
                
                utilizador.DataRegisto = System.DateTime.Now;

                utilizador.UtilizadoresSeguidos = new List<Utilizador>();
                utilizador.Seguidores = new List<Utilizador>();
                utilizador.Comentarios = new List<Comentario>();
                utilizador.Publicacoes = new List<Publicacao>();
                utilizador.MensagensEnviadas = new List<Mensagem>();
                utilizador.MensagensRecebidas = new List<Mensagem>();

                db.Utilizadores.Add(utilizador);
                db.SaveChanges();
                imagem.AutorID = utilizador.UtilizadorID;
                db.SaveChanges();

                Session["Utilizador"] = utilizador;
                Session["Login"] = true;

                return RedirectToAction("Perfil", "Utilizadores");
            }

            ViewBag.Erro = true;
            ViewBag.DistritoID = new SelectList(db.Distritos, "DistritoID", "Nome", utilizador.DistritoID);
            ViewBag.TituloID = new SelectList(db.Titulos, "TituloID", "Nome", utilizador.TituloID);
            return View(utilizador);
        }



        public ActionResult LocaisFavoritos() {

            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Utilizador sessao = (Utilizador)Session["Utilizador"];

            if (sessao == null)
            {
                return HttpNotFound();
            }

            Utilizador utilizador = db.Utilizadores.Find(sessao.UtilizadorID);

            if (utilizador == null)
            {
                return HttpNotFound();
            }

            Session["Login"] = true;
            Session["Utilizador"] = utilizador;

            return View(utilizador);
        }

        public ActionResult UtilizadoresFavoritos()
        {

            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Utilizador sessao = (Utilizador)Session["Utilizador"];

            if (sessao == null)
            {
                return HttpNotFound();
            }

            Utilizador utilizador = db.Utilizadores.Find(sessao.UtilizadorID);

            if (utilizador == null)
            {
                return HttpNotFound();
            }

            Session["Login"] = true;
            Session["Utilizador"] = utilizador;

            return View(utilizador);
        }

        public ActionResult OrganizacoesFavoritas()
        {

            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Utilizador sessao = (Utilizador)Session["Utilizador"];

            if (sessao == null)
            {
                return HttpNotFound();
            }

            Utilizador utilizador = db.Utilizadores.Find(sessao.UtilizadorID);

            if (utilizador == null)
            {
                return HttpNotFound();
            }

            Session["Login"] = true;
            Session["Utilizador"] = utilizador;

            return View(utilizador);
        }

    }
}