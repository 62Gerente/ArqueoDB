using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArqueoDB.Models;
using ArqueoDB.DAL;

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

            Utilizador utilizador = db.Utilizadores.Find(id);
            Utilizador utilizadorSeguir = db.Utilizadores.Find(seguir);

            utilizador.UtilizadoresSeguidos.Add(utilizadorSeguir);

            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult DeixarSeguir(int id, int seguir)
        {

            Utilizador utilizador = db.Utilizadores.Find(id);
            Utilizador utilizadorSeguir = db.Utilizadores.Find(seguir);

            utilizador.UtilizadoresSeguidos.Remove(utilizadorSeguir);
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult Comentar(int id, int user, string comentario) {
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

        [HttpPost]
        public ActionResult Inbox(int id, int recept, String assunto, String corpo)
        {

            Utilizador s = db.Utilizadores.Find(id);
            Utilizador r = db.Utilizadores.Find(id);
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

        [HttpPost]
        public ActionResult Login()
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


        public ActionResult Logout()
        {
            Session["Utilizador"] = null;
            Session["Login"] = null;
            return RedirectToAction("Index", "Home");

        }
    }
}