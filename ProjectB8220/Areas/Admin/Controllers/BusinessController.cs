using Project.BAL.Repositories;
using Project.Models.DataModels;
using ProjectB8220.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectB8220.Areas.Admin.Controllers
{
    public class BusinessController : Controller
    {
        Repository<Business> _business;
        public BusinessController()
        {
            _business = new Repository<Business>();
        }
        // GET: Admin/Business
        public ActionResult Index()
        {
            return View(_business.GetAll());
        }
        public ActionResult UpadteBusiness()
        {
            Reflection rf = new Reflection();
            //Lấy tất cả các controller
            var controller = rf.GetControllers("ProjectB8220.Areas.Admin.Controllers").Select(x => x.Name.Replace("Controller",""));
            var oldBusiness = _business.GetAll();

            foreach (var item in controller)
            {
                //Kiểm tra business trong db 
                if (!oldBusiness.Any(x => x.BusinessId == item))
                {
                    Business b = new Business()
                    {
                        BusinessId = item,
                        BusinessName = "Đang cập nhật...",
                        Status = true
                    };
                    _business.Add(b);
                }
            }
            return RedirectToAction("Index");
        }
    }
}