using Project.BAL.Repositories;
using Project.Models.DataModels;
using ProjectB8220.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectB8220.Controllers
{
    public class ShoppingCartsController : Controller
    {
        Repository<Order> _orders;
        Repository<Product> _products;
        public ShoppingCartsController()
        {
            _products = new Repository<Product>();
            _orders = new Repository<Order>();
        }
        // GET: ShoppingCart
        public ActionResult Index()
        {
            List<CartItem> lst = new List<CartItem>();
            if (Session["cart"] != null)
            {
                //Lấy các sp trong session ra list
                lst = Session["cart"] as List<CartItem>;
            }
            return View(lst);
        }
        public ActionResult AddToCart(int ProductId)
        {
            //Lấy sản phẩm cần thêm vào theo Id
            var _product = _products.GetAll().FirstOrDefault(x => x.ProductId == ProductId);
            //Lấy số lượng
            var qty = Convert.ToInt32(Request["qty"]);

            CartItem cart = new CartItem()
            {
                Product = _product,
                Quantity = qty
            };
            //Giỏ hàng sẽ lưu trong list này
            List<CartItem> lst = new List<CartItem>();

            //Kiểm tra giỏ hàng đã tồn tại hay chưa
            if (Session["cart"] != null)// Đã có giỏ hàng
            {
                //Lấy các sp trong session ra list
                lst = Session["cart"] as List<CartItem>;

                //Kiểm tra sản phẩm đã có trong giỏ hàng chưa
                var check = false;
                foreach (var item in lst)
                {
                    if (item.Product.ProductId == ProductId)
                    {
                        item.Quantity += cart.Quantity;
                        check = true;
                    }
                }
                if (!check) //Nếu chưa có trong giỏ thì thêm mới
                {
                    lst.Add(cart);
                }

            }
            else //Nếu chưa có sản phẩm nào trong giỏ thì thêm mới 
            {
                lst.Add(cart);
            }
            //Lưu trữ list trong Session
            Session["cart"] = lst;
            return RedirectToAction("Index");
        }
        public ActionResult Payment()
        {
            if (Session["customer"] == null) // Người dùng chưa đăng nhập
            {
                return RedirectToAction("Login", "Customers");//Trả về trang đăng nhập
            }
            //Kiểm tra giỏ hàng
            if (Session["cart"] == null)
            {
                return RedirectToAction("Index");//Trả về trang hiện tại
            }
            List<CartItem> lst = new List<CartItem>();

            //Lấy các sp trong session ra list
            lst = Session["cart"] as List<CartItem>;
            if (lst.Count == 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Payment(Order o)
        {
            o.Created = DateTime.Now;
            o.Status = 1;
            if (Session["cart"] == null)
            {
                return RedirectToAction("Index");//Trả về trang hiện tại
            }

            List<CartItem> lst = new List<CartItem>();

            //Lấy các sp trong session ra list
            lst = Session["cart"] as List<CartItem>;
            //Tạo đối tượng OrderDetails
            List<OrderDetails> orderDetails = new List<OrderDetails>();
            foreach (var item in lst)
            {
                OrderDetails od = new OrderDetails();
                od.ProductId = item.Product.ProductId;
                od.Quantity = item.Quantity;
                od.Price = item.Product.Price;

                orderDetails.Add(od);

            }
            o.OrderDetails = orderDetails;
            if (_orders.Add(o))
            {
                //Nội dung mail
                string Header = System.IO.File.ReadAllText(Server.MapPath(@"~App_Data/Header.txt"));
                string Footer = System.IO.File.ReadAllText(Server.MapPath(@"~App_Data/Footer.txt"));
                string main = String.Format(@"<h2 class='title'>ĐƠN HÀNG BKAP</h2>

                < p >

                    < b > Họ tên người nhận </ b >
   
                       < span > {0}</ span >
   
                   </ p >
   
                   < p >
   
                       < b > Email </ b >
   
                       < span >{1}/ span >
   
                   </ p >
   
                   < p >
   
                       < b > SĐT </ b >
   
                       < span >{2}</ span >
   
                   </ p >
   
                   < p >
   
                       < b > Địa chỉ </ b >
      
                          < span >{3}</ span >
      
                      </ p >
      
                      < p >
      
                          < b > Ngày mua </ b >
         
                             < span >{4}</ span >
         
                         </ p >", o.FullName , o.Email , o.Phone , o.Address , o.Created);
                main += @"<table class='table text-center'>
                    < thead >

                        < tr >

                            < th > Sản phẩm </ th >
   
                               < th > Đơn giá </ th >
      
                                  < th > Số lượng </ th >
         
                                     < th > Thành tiền </ th >
            
                                    </ tr >
            
                                </ thead >
            
                                < tbody >";
                foreach (var item in lst)
                {
                    main += "< tr >";

                    main += "< td >"+item.Product.ProductName+"</ td >";

                    main += "< td >"+item.Product.Price+" </ td >";

                    main += "< td >"+item.Quantity+"</ td >";

                    main += "< td >"+(item.Quantity * item.Product.Price)+"</ td >";

                    main += "</ tr >";
                }
                main += @"</tbody>
				</table>";
                Helper.SendEmail(o.Email, "tunabka@gmail.com", "tuhouse0710", "[Đơn hàng]", Header+main+Footer);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}