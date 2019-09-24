using Project.BAL.Repositories;
using Project.Models.DataModels;
using Project.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectB8220.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        Repository<User> _users;
        Repository<GroupRole> _grouprole;
        public AccountController()
        {
            _users = new  Repository<User>();
            _grouprole = new Repository<GroupRole>();
        }
        public ActionResult Login()
        {
            return View();
        }
        // GET: Admin/Account
        [HttpPost]
        public ActionResult Login(UserLogin u)
        {
            var _u = _users.GetAll().FirstOrDefault(x => x.UserName == u.UserName && x.Password == u.Password);
            if (_u != null) // Đăng nhập thành công
            {
                Session["user"] = _u;
                //Lấy ra danh sách quyền //Sau khi lấy ra group và quyền thì lưu dưới dạng chuỗi(Select) 
                var permissions = _grouprole.GetBy(x => x.GroupId == _u.GroupId).Select(x => x.BusinessId+"_"+x.RoleId).ToList();
                Session["roles"] = permissions;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}