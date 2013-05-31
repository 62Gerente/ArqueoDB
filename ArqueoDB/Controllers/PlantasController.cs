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
    public class PlantasController : Controller
    {
        private EntidadesArqueoDB db = new EntidadesArqueoDB();

        public ActionResult Publicar(int id)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Planta p = db.Plantas.Find(id);
            p.Publico = true;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult Ocultar(int id)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Planta p = db.Plantas.Find(id);
            p.Publico = false;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult Remover(int id)
        {
            if (Session["Utilizador"] == null)
            {
                Session["ErroSessao"] = true;
                return RedirectToAction("Login", "Utilizadores");
            }

            Planta p = db.Plantas.Find(id);
            p.Apagado = true;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }
    }
}