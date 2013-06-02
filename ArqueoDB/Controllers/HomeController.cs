using System;
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
    public class HomeController : Controller
    {

        private EntidadesArqueoDB db = new EntidadesArqueoDB();
        public ActionResult Index()
        {
            List<Local> locs = new List<Local>();
            List<Publicacao> listapub = new List<Publicacao>();
            Dictionary<Publicacao, String> pubdetails = new Dictionary<Publicacao, String>();
            Dictionary<Publicacao, String> publicacoes = new Dictionary<Publicacao, String>();
            foreach (Local l in db.Locais.Where(l => l.Publico && !l.Apagado)) { locs.Add(l); }
            locs.OrderByDescending(l => l.Comentarios.Count());
            ViewBag.locals = locs;

            foreach (Local loc in locs)
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








            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
