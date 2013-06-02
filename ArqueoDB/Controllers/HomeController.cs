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
            foreach (Local l in db.Locais) { locs.Add(l); }

            ViewBag.locals = locs;
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
