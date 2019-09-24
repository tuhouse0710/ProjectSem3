using Project.BAL.Repositories;
using Project.Models.DataModels;
using Project.Models.ViewModels;
using ProjectB8220.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectB8220.Controllers
{
    public class CustomersController : Controller
    {
        Repository<Customer> _customer;
        public CustomersController()
        {
            _customer = new Repository<Customer>();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer c)
        {
            if (ModelState.IsValid)
            {
                var _cus = _customer.GetAll().FirstOrDefault(x => x.Email == c.Email && x.Password == c.Password);
                if (_cus != null)
                {
                    Session["customer"] = _cus;
                    return RedirectToAction("Index", "Home");

                }
                ViewBag.err = "Sai tài khoản hoặc mật khẩu";
                return View();
            }
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(CustomerRegister c)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra nếu có tài khoản đăng ký email này rồi
                if (_customer.GetBy(x => x.Email == c.Email).Count() > 0)
                {
                    ModelState.AddModelError("Email", "Email đã tồn tại!");
                    return View();
                }
                Customer _c = new Customer();
                _c.FirstName = c.FirstName;
                _c.LastName = c.LastName;
                _c.Email = c.Email;
                _c.Password = c.Password;
                if (_customer.Add(_c))
                {
                    Helper.SendEmail(c.Email, "tunabka@gmail.com", "tuhouse0710", "[Đăng ký tài khoản]",String.Format(@"
                           <h1>Đăng ký tài khoản thành công!</h1>
                           <b>Email đăng ký: </b> {0}
                           ",c.Email));
                    return RedirectToAction("Login");
                }
                return View();
            }
            return View();
        }
    }
}