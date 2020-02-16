using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Commercial.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Stripe;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
namespace Commercial.Controllers
{
    public class ShoppingCartController: Controller
    {
        private readonly MyContext dbcontext;
        private readonly ShoppingCart mycart;
        public ShoppingCartController(MyContext context, ShoppingCart shoppingCart)
        {
            dbcontext=context;
            mycart=shoppingCart;
        }
        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            
            var items=mycart.GetCartItems();
            
            return View(items);
        }
        [Route("addtocart")]
        [HttpPost]
        public IActionResult AddToCart(Product n)
        {
            var cart= mycart.GetCart(this);
            cart.AddToCart(n, n.Quantity);
            return RedirectToAction("Checkout");
        }
        [Authorize]  
        [Route("checkout")]
        [HttpGet]
        public IActionResult Checkout()
        {
            ViewBag.purchases=mycart.GetCartItems();
            return View();
        }
        /*  public IActionResult AddToCart(Product k)
        {
            
            ViewBag.indb=dbcontext.products.FirstOrDefault(q=>q.ProductId==k.ProductId);
            var oneorder=new Order();
            var mycart=new Cart();
            var z=new List<Order>();
            oneorder.product=ViewBag.indb;
            oneorder.Quantity=k.Quantity;
            int i=0;
            //mycart.purchases.Add(oneorder);
            
            if (HttpContext.Session.GetObjectFromJson<List<Order>>("cart")==null)
                {
                    z.Insert(i, oneorder);
                    i++;
                    HttpContext.Session.SetObjectAsJson("cart", z);
                    return RedirectToAction("Dashboard");
                }
            
            //if (z.ContainsKey(k.ProductId))
           // {
               // return RedirectToAction("Dashboard");
            //}
            
                    var t= HttpContext.Session.GetObjectFromJson<List<Order>>("cart");
                    t.Add(oneorder);
                    HttpContext.Session.SetObjectAsJson("cart", t);
                    return RedirectToAction("Dashboard");
              
                
        }*/
        

    }
}