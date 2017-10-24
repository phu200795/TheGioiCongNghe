using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGioiCongNghe.Models;
using TheGioiCongNghe.ViewModels;
using System.Web.Script.Serialization;
namespace TheGioiCongNghe.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public CartController()
        {
            dbContext = new ApplicationDbContext();
        }
        // GET: Cart
        public ActionResult ListCartItem()
        {
            var cart = Session["ShoppingCart"];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public JsonResult AddToCart(int id)
        {
            List<CartItem> listCartItem;
            if(Session["ShoppingCart"]==null)
            {
                listCartItem = new List<CartItem>();
                listCartItem.Add(new CartItem { Quantity = 1, Product = dbContext.Product_managers.Find(id) });
                Session["ShoppingCart"]=listCartItem;
            }
            else
            {
                bool flag = false;
                listCartItem = (List<CartItem>)Session["ShoppingCart"];
                foreach(CartItem item in listCartItem)
                {
                    if(item.Product.Id==id)
                    {
                        item.Quantity++;
                        flag = true;
                        break;

                    }

                }
                if(!flag)
                    listCartItem.Add(new CartItem { Quantity = 1, Product = dbContext.Product_managers.Find(id) });
                Session["ShoppingCart"] = listCartItem;
            }
            int cartcount = 0;
            List<CartItem> ls = (List<CartItem>)Session["ShoppingCart"];
            foreach(CartItem item in ls)
            {
                cartcount += item.Quantity;
            }
            return Json(new { ItemAmount = cartcount });
        }
        public ActionResult GetShppingCart()
        {
            int cartcount = 0;
            if (Session["ShoppingCart"] != null)
            {
                List<CartItem> ls = (List<CartItem>)Session["ShoppingCart"];
                foreach (CartItem item in ls)
                {
                    cartcount += item.Quantity;
                }
            }
            return PartialView("ShoppingCartPartial", cartcount);
        }
        public JsonResult Update(string cartModel)
        {
            var jsoncart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessioncart = (List<CartItem>)Session["ShoppingCart"];
            foreach(var item in sessioncart)
            {
                var jsonitem = jsoncart.SingleOrDefault(x => x.Product.Id == item.Product.Id);
               if(jsonitem !=null)
                {
                    item.Quantity = jsonitem.Quantity;
                }
       
                
            }
            Session["ShoppingCart"] = sessioncart;
            return Json(new
            {
                status=true
            });
        }
        public JsonResult DeleteAll()
        {
            Session["ShoppingCart"] =null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(int id)
        {
            var sessioncart = (List<CartItem>)Session["ShoppingCart"];
            sessioncart.RemoveAll(x => x.Product.Id == id);
            Session["ShoppingCart"] = sessioncart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult Payment()
        {
            var cart = Session["ShoppingCart"];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(string shipName,string Phone, string Address,string Email)
        {
            var order = new Order();
            order.CreatDate = DateTime.Now;
            order.ShipAddress = Address;
            order.ShipMobie = Phone;
            order.ShipName = shipName;
            order.ShipEmail = Email;
            var id=dbContext.Orders.Add(order);
            dbContext.SaveChanges();
            var cart= (List<CartItem>)Session["ShoppingCart"];
            foreach(var item in cart)
            {
                var orderDetail = new Order_Details();
                orderDetail.ProductId = item.Product.Id;
                orderDetail.OrderId = id.Id;
                orderDetail.Quantity = item.Quantity;
                orderDetail.Price = (int)item.Product.Product_Price;
                dbContext.Order_Detailss.Add(orderDetail);
            }
            dbContext.SaveChanges();
            
            return RedirectToAction("Index", "Home");
        }
    }
}