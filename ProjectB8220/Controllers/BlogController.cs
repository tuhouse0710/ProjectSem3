using Project.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectB8220.Controllers
{
    public class BlogController : Controller
    {
        private List<Blog> Blogs;
        public BlogController()
        {
            Blogs = new List<Blog>()
            {
                new Blog { PostId = 1 ,  PostTitle = "Top 3 sách bán chạy nhất mọi thời đại" , PostContent = "Hồng lâu mộng , Anh chàng Hobbit , Chuyện hai thành phố" , Author = "Anh Tú", FeatureImg = "" },
                new Blog { PostId = 2 ,  PostTitle = "Sách thiếu nhi hay nhất" , PostContent = "Tấm Cám , Cây khế , Cây tre trăm đốt" , Author = "Anh Tú", FeatureImg = "" },
                new Blog { PostId = 3 ,  PostTitle = "Sách lập trình hay nhất" , PostContent = "Hồng lâu mộng , Anh chàng Hobbit , Chuyện hai thành phố" , Author = "Anh Tú", FeatureImg = "" }
                
            };
        }
        // GET: Blog //Hiển thị danh sách post trong trang Blog
        public ActionResult Index()
        {
            //Truyền dữ liệu từ Action ra View sử dụng ViewBag
            ViewBag.blg = Blogs;
            return View();
        }
    }
}