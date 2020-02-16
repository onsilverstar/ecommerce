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
using System.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
namespace Commercial.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbcontext;
        public HomeController(MyContext context)
        {
            dbcontext=context;
            
        }
        [Route("")]
        [HttpGet]
        [HttpPost]
        public IActionResult Dashboard(Product c)
        {
            var productorders=dbcontext.products.ToList();
            if (c.Title==""||c.Title==null)
            {
                
                ViewBag.products=productorders;
                return View();
            }
            ViewBag.products=productorders.Where(d=>d.Title==c.Title);
            return View();
        }
        [Route("orders")]
        [HttpGet]
        public IActionResult AllOrders()
        {
            var myuserswithorders=dbcontext.cartitems.Include(k=>k.customer).ToList();
             
            return View(myuserswithorders);
        }
        [Route("addorders")]
        [HttpPost]
        /* public IActionResult AddOrder(OrderItem newone)
        {
            var neworder=new Order();
            var getproduct=dbcontext.products.FirstOrDefault(t=>t.Title==newone.Item);
            if (getproduct.InitialQuantity>=newone.Order)
            {
            neworder.customer=dbcontext.customers.FirstOrDefault(d=>d.Name==newone.Customer);
            getproduct.InitialQuantity-=newone.Order;
            //neworder.product=getproduct;
            dbcontext.order.Add(neworder);
            dbcontext.SaveChanges();
            return RedirectToAction("Orders");
            }
            ModelState.AddModelError("Item", "We have fewer items in stock for this product");
            return RedirectToAction("Orders");
        }*/
        [Route("customers")]
        [HttpGet]
        [HttpPost]
        public IActionResult Customers(User t)
        {
            if (t.Name==""||t.Name==null)
            {
                ViewBag.customers=dbcontext.customers.ToList();
                return View();
            }
            ViewBag.customers=dbcontext.customers.Where(v=>v.Name.Contains(t.Name));
            return View("Customers");
            
            
        }
        
        [Route("addcustomer")]
        [HttpPost]
        public IActionResult AddCustomer(User newcustomer)
        {
            
            if(dbcontext.customers.Any(p=>p.Name==newcustomer.Name))
            {
                ModelState.AddModelError("Name","Name is not available!");
                return View("Customers");
            }
            var addcustomer=new User();
            addcustomer.Name=newcustomer.Name;
            addcustomer.CreatedAt=DateTime.Now;
            dbcontext.customers.Add(addcustomer);
            dbcontext.SaveChanges();
           
        return RedirectToAction("Customers");
            
        }
        [Route("remove/{CustomerId}")]
        [HttpGet]
        public IActionResult Remove(int CustomerId)
        {
            var toremove=dbcontext.products.FirstOrDefault(v=>v.ProductId==CustomerId);
            //dbcontext.Remove(toremove);
            dbcontext.SaveChanges();
            return RedirectToAction("Customers");
            
        }
        [Route("products")]
        [HttpGet]
        [HttpPost]
        public IActionResult Products(Product m)
        {
            
            if (m.Title==null||m.Title=="")
            {
                ViewBag.products=dbcontext.products.ToList();
                return View();
            }
            
            ViewBag.products=dbcontext.products.Where(t=>t.Title.Contains(m.Title)).ToList();
            return View();
            
            
        }
        [Route("addproducts")]
        [HttpPost]
        public IActionResult AddProducts(Product newproduct)
        {
            var toadd=new Product();
            toadd.Title=newproduct.Title;
            toadd.Image=newproduct.Image;
            toadd.Description=newproduct.Description;
            toadd.Price=newproduct.Price;
            toadd.InitialQuantity=newproduct.InitialQuantity;
            toadd.Quantity=newproduct.Quantity;
            dbcontext.products.Add(toadd);
            dbcontext.SaveChanges();
            return RedirectToAction("Products");
            
        }
        
        public IActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customerService=new StripeCustomerService();
            var chargeService=new StripeChargeService();
            var customer=customerService.Create(new StripeCustomerCreateOptions {Email=stripeEmail, SourceToken=stripeToken});
            var charge=chargeService.Create(new StripeChargeCreateOptions{Amount=500, Description="Wow!", Currency="usd", CustomerId=customer.Id});
        
            return View("Products");
        }
        [Route("settings")]
        [HttpGet]
        public IActionResult Settings()
        {
            return View("Index");
        }
        
        [Route("viewproduct{productid}")]
        [HttpGet]
        public IActionResult ViewProduct(int productid)
        {
            ViewBag.product=dbcontext.products.FirstOrDefault(h=>h.ProductId==productid);
            ViewBag.similar=dbcontext.products.Where(t=>t.Title.Contains(dbcontext.products.FirstOrDefault(h=>h.ProductId==productid).Title)).Where(n=>n.ProductId!=productid).ToList();
            //if (HttpContext.Session.GetObjectFromJson<List<Order>>("cart")!=null)
            
                //var ordersbought=HttpContext.Session.GetObjectFromJson<List<Order>>("cart").ToList();
                var products=new List<Product>();
                //foreach(var v in ordersbought)
               // {
                   // products.Add(v.product);

                //}
                ViewBag.purchases=products;
               // HttpContext.Session.SetObjectAsJson("purchases", products);
                //return View("ViewProduct");
        
            
            ViewBag.purchases=new List<Product>{}; 
            return View("ViewProduct");
        }
        [Route("Adminlogin")]
        [HttpGet]
        [Authorize(Roles="Level3")]
        public IActionResult AdminLogin()
        {
            return View();
        }
        

    }
}

