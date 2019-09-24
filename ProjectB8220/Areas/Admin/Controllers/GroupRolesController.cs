using Project.BAL.Repositories;
using Project.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectB8220.Areas.Admin.Controllers
{
    public class GroupRolesController : Controller
    {
        Repository<GroupRole> _grouprole;
        public GroupRolesController()
        {
            _grouprole = new Repository<GroupRole>();
        }
        public ActionResult Get(int id)
        {

            var data = _grouprole.GetBy(x => x.GroupId == id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        // GET: Admin/GroupRoles
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UpdatePermison(GroupRole gr)
        {
            //Kiểm tra quyền đã được chọn hay chưa
            if (_grouprole.GetAll().Any(x => x.GroupId == gr.GroupId && x.RoleId == gr.RoleId && x.BusinessId == gr.BusinessId)) 
            {
                //Lấy đối tượng cần xóa
                var objects =  _grouprole.GetAll().FirstOrDefault(x => x.GroupId == gr.GroupId && x.RoleId == gr.RoleId && x.BusinessId == gr.BusinessId);
                _grouprole.Remove(objects);
                return Json(new
                {

                }, JsonRequestBehavior.AllowGet);
            } else {
                _grouprole.Add(gr);
                return Json(new
                {

                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}