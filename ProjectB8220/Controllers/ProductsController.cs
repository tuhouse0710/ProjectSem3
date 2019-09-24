using Project.BAL.Repositories;
using Project.Models;
using Project.Models.DataModels;
using ProjectB8220.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectB8220.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        C1709M_PROJ db;
        public ProductsController()
        {
            db = new C1709M_PROJ();
        }
        // GET: Products
        public ActionResult Index()
        {
            ViewBag.related = db.Products.ToList();
            return View();
        }
        public ActionResult Details(int id)
        {
            var data = db.Products
                .Include(x => x.Categories)
                .FirstOrDefault(x => x.ProductId == id);
            return View(data);
        }
    }
}