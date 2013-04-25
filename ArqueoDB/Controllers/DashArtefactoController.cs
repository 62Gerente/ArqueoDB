using ArqueoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ArqueoDB.DAL;

namespace ArqueoDB.Controllers
{
    public class DashArtefactoController : Controller
    {
        private EntidadesArqueoDB db = new EntidadesArqueoDB();

        // GET: /DashboardArtefactos/Dashboard

        public ActionResult Dashboard(int id)
        {
            Artefacto artefacto = db.Artefactos.Find(id);
            if (artefacto == null)
            {
                return HttpNotFound();
            }

            ViewData["Dashboard"] = "Artefacto";
            ViewData["Activo"] = "Dashboard";

            return View(artefacto);
        }
    }
}
