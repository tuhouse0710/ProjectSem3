using Project.BAL.Repositories;
using Project.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectB8220.Areas.Admin.Controllers
{
    public class GroupsController : Controller
    {
        Repository<Group> _group;
        Repository<Business> _business;
        Repository<Role> _role;
       
        public GroupsController()
        {
            _group = new Repository<Group>();
            _business = new Repository<Business>();
            _role = new Repository<Role>();
        
        }
        
        // GET: Admin/Groups
        public ActionResult Index()
        {
            ViewBag.Businesses = _business.GetAll();
            ViewBag.Roles = _role.GetAll();
            return View(_group.GetAll());
        }
        
    }
}