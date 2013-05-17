using ArqueoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult Artefactos(int id = 0)
        {
            Local local = db.Locais.Find(id);
            if (local == null)
            {
                return HttpNotFound();
            }

            ViewData["Dashboard"] = "Local";
            ViewData["Activo"] = "Artefactos";

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
        public ActionResult Documentos(int id = 0)
        {
            Local local = db.Locais.Find(id);
            if (local == null)
            {
                return HttpNotFound();
            }

            ViewData["Dashboard"] = "Local";
            ViewData["Activo"] = "Documentos";

            return View(local);
        }

        public ActionResult Definicoes(int id = 0)
        {
            Local local = db.Locais.Find(id);
            if (local == null)
            {
                return HttpNotFound();
            }

            ViewData["Dashboard"] = "Local";
            ViewData["Activo"] = "Definições";

            return View(local);
        }
    }
}
