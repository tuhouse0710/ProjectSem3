using Project.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectB8220.Areas.Admin.Models
{
    //Tạo lớp check quyền
    public class CustomizeAuthAttribute : AuthorizeAttribute //CAA kế thừa lại từ lớp Author
    {
        
        //Cho phép gán các quyền

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            
            //Kiểm tra đăng nhập
            if (HttpContext.Current.Session["user"] == null)
            {
                return false;
 
            }
            var _user = (User)HttpContext.Current.Session["user"] == null;
            //Lấy các quyền được yêu cầu
            var requiredRoles = this.Roles.Split(',').Where(x => !String.IsNullOrEmpty(x)).ToList();
            //Lấy tên controller hiện tại
            var rd = HttpContext.Current.Request.RequestContext.RouteData;
            string _ctrl = rd.GetRequiredString("controller");
            if (requiredRoles.Count > 0) //Có yêu cầu quyền
            {
                //Lấy cac quyền của user hiện tại
                var _roles = HttpContext.Current.Session["roles"] as IEnumerable<string>;
                //Kiểm tra có tồn tại các quyền yêu cầu trong số quyền đã gán hay không
                var check = false;
                foreach (var item in requiredRoles)
                {
                    var _r = _ctrl + "_" + item;
                    if (_roles.Any(x => x == _r))
                    {
                        check = true;
                        break;
                    }
                    if (check)
                    {
                        //Nếu có quyền truy cập thì trả về true
                        return true;
                    } else
                    {
                        //Nếu không có quyền trả về false
                        return false;
                    }
                }
            }
            return true;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //Muốn xử lí không có quyền truy câp => điều hướng tới trang khác
            // Xử lí ở đây
            base.HandleUnauthorizedRequest(filterContext);
        }

    }
}