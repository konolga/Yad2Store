using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using yad2.Models;

namespace yad2.Controllers
{
    public class CartController : Controller
    {
        private Yad2DbContext db = new Yad2DbContext();
       
        // GET: Cart
        public ActionResult AddToCart(Product product)
        {
            List<Product> listView = (List<Product>)Session["view"];

                //Creating a session "Session["cart"]" which is null for the first time, for all users
                if (Session["cart"] == null)
                {
                    List<Product> list = new List<Product>();
                    list.Add(product);
                    Session["cart"] = list;
                }
                else
                    //if the "Session["cart"] is not null, then adding one more list item to the session
                    //and increasing the counter as per the number of products added
                {
                    List<Product> list = (List<Product>) Session["cart"];
                    list.Add(product);
                    Session["cart"] = list;
                   
                }
            listView.RemoveAll(x => x.Id == product.Id); //when add to cart, we remove from home page
            Session["view"] = listView;
            return View("Cart", Session["cart"]);
           
    }


        public ActionResult MyOrder()
        {

            return View("Cart",(List<Product>)Session["cart"]);

        }

        public ActionResult Remove(Product product)
        {
            List<Product> list = (List<Product>)Session["cart"];
            List<Product> listView = (List<Product>)Session["view"];

            list.RemoveAll(x => x.Id == product.Id);
            listView.Add(product);

            Session["cart"] = list;
            Session["view"] = listView;
            return RedirectToAction("MyOrder", "Cart");

        }

        public ActionResult BuyAll()
        { 
            List<Product> list = (List<Product>)Session["cart"];
            var users = db.Users.ToList();
            foreach (var item in list)
            {
                db.Products.Attach(item);
                if (Request.IsAuthenticated)
                {
                  var username =  System.Web.HttpContext.Current.User.Identity.Name;
                  item.OwnerId = users.Find(u => u.UserName == username)?.Id;
                }
               
                else item.OwnerId = null; //change the owner of the product
                
                item.State = 1;  //1 is sold
            }

            db.SaveChanges();
            list.Clear();
            Session["cart"] = list;
            return RedirectToAction("MyOrder", "Cart");
        }
    }
}