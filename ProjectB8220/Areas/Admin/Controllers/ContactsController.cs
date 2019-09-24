using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectB8220.Areas.Admin.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Admin/Contacts
        public ActionResult Index()
        {
            return View();
        }
    }
}