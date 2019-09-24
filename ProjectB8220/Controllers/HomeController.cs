using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectB8220.Controllers
{
    public class HomeController : Controller
    {
        C1709M_PROJ db;
        public HomeController()
        {
            db = new C1709M_PROJ();
        }
        public ActionResult Index()
        {
            ViewBag.related = db.Products.Where(x => x.Status == true && x.Related == true);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}