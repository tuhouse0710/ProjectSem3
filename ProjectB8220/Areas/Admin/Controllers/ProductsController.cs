using Project.BAL.Repositories;
using Project.Models.DataModels;
using ProjectB8220.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectB8220.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        
        Repository<Product> _product;
        Repository<Category> _cat;

        public ProductsController()
        {
            _product = new Repository<Product>();
            _cat = new Repository<Category>();
        }
        [CustomizeAuth(Roles = "View")]
        // GET: Admin/Products
        public ActionResult Index()
        {
            return View(_product.GetAll().AsQueryable().Include(x => x.Categories));
        }


        [CustomizeAuth(Roles = "Add")]
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(_product.GetAll(),"ProductId","ProductName");
            return View();
        }
        [CustomizeAuth(Roles = "Add")]
        [HttpPost]
        public ActionResult Create(Product p)
        {
            ViewBag.ProductId = new SelectList(_product.GetAll(), "ProductId", "ProductName");
            if (ModelState.IsValid)
            {

                if (_product.Add(p))
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }


        [CustomizeAuth(Roles = "Edit")]
        public ActionResult Edit(int id)
        {
            ViewBag.ProductId = new SelectList(_product.GetAll(), "ProductId", "ProductName");
            return View(_product.Get(id));
        }
        [CustomizeAuth(Roles ="Edit")]
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            ViewBag.ProductId = new SelectList(_product.GetAll(), "ProductId", "ProductName");
            if (ModelState.IsValid)
            {

                if (_product.Edit(p))
                {

                    return RedirectToAction("Index");
                }
            }
            return View();
        }


        [CustomizeAuth(Roles = "Delete")]
        public  ActionResult Delete(int id)
        {
            //Tìm đối tượng cần xóa
            var _p = _product.Get(id);



            //Xóa sản phẩm
            _product.Remove(_p);

            //Sau khi xóa xong
            TempData["Thông báo"] = "Xóa sản phẩm thành công";
            return RedirectToAction("Index");

        }
    }
}