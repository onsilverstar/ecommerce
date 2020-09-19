using System;
using System.IO;
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
using Microsoft.AspNetCore.Hosting;
namespace Commercial.Controllers
{
    public class HomeController : Controller
    {
        private string GetUniqueFileName(string fileName)
            {
                fileName = Path.GetFileName(fileName);
                return  Path.GetFileNameWithoutExtension(fileName)
                        + "_" 
                        + Guid.NewGuid().ToString().Substring(0, 4) 
                        + Path.GetExtension(fileName);
            }
        private MyContext dbcontext;
        private readonly IHostingEnvironment hostingEnvironment;
        public HomeController(MyContext context, IHostingEnvironment environment)
        {
            dbcontext=context;
            hostingEnvironment=environment;
            
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
            //var myuserswithorders=dbcontext.cartitems.Include(k=>k.customer).ToList();
             
            return View();
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
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View("AddProduct");
            
        }
        [Route("processaddproducts")]
        [HttpPost]
        public IActionResult ProcessAddProduct(Product newproduct)
        {
            Product toadd=new Product();
            toadd.Title=newproduct.Title;
            toadd.Description=newproduct.Description;
            toadd.Price=newproduct.Price;
            toadd.InitialQuantity=newproduct.InitialQuantity;
            if(newproduct.photo!=null)
            {
                var newproductFileName=Guid.NewGuid().ToString()+"_"+newproduct.photo.FileName;
                var newproductUpload=Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                var newproductFilePath=Path.Combine(newproductUpload, newproductFileName);
                var newfile=new FileStream(newproductFilePath, FileMode.Create);
                newproduct.photo.CopyTo(newfile);
                newfile.Close();
                toadd.Image=newproductFileName;
                dbcontext.products.Add(toadd);
            }
            dbcontext.SaveChanges();
            
            return View("AddProduct");
            
        }
        [Route("Home/Charge")]
        [HttpPost]
        public IActionResult Charge(string stripeEmail, string stripeToken)
        {
            //for testing use testmode card no: 4242424242424242 with any future date and any three digits for cvv
            var customerService=new StripeCustomerService();
            var chargeService=new StripeChargeService();
            var customer=customerService.Create(new StripeCustomerCreateOptions {Email=stripeEmail, SourceToken=stripeToken});
            var charge=chargeService.Create(new StripeChargeCreateOptions{Amount=500, Description="Wow!", Currency="usd", CustomerId=customer.Id});
            //int orderid=HttpContext.Session.GetObjectFromJson<int>("orderid")+1;
            var toupdate=HttpContext.Session.GetObjectFromJson<Order>("currentorder");
            toupdate.Paid=true;
            dbcontext.orders.Update(toupdate);
            dbcontext.SaveChanges();
    
        
            return RedirectToAction("Dashboard");
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
            var product=dbcontext.products.FirstOrDefault(h=>h.ProductId==productid);
            ViewBag.product=product;
            ViewBag.similar=dbcontext.products.Where(t=>t.Title.Contains(dbcontext.products.FirstOrDefault(h=>h.ProductId==productid).Title)).Where(n=>n.ProductId!=productid).ToList();
            var products=new List<Product>();
            if (HttpContext.Session.GetObjectFromJson<List<Product>>("cart")!=null)
            {
                var ordersbought=HttpContext.Session.GetObjectFromJson<List<Product>>("cart").ToList();
                foreach(var v in ordersbought)
                {
                    products.Add(v);
                }
            }
            
                ViewBag.purchases=products;
    
            return View("ViewProduct");
        }
        [Route("Adminlogin")]
        [HttpGet]
        [Authorize(Roles="Level3")]
        public IActionResult AdminLogin()
        {
            return View();
        }
        [Route("addtocart")]
        [HttpPost]
        public IActionResult AddToCart(Product m)
        {
            var product=dbcontext.products.FirstOrDefault(n=>n.ProductId==m.ProductId);
            product.Quantity=m.Quantity;
            var products=new List<Product>();
            products.Add(product);
            if (HttpContext.Session.GetObjectFromJson<List<Product>>("cart")!=null)
            {
            var ordersbought=HttpContext.Session.GetObjectFromJson<List<Product>>("cart").ToList();

                foreach(var v in ordersbought)
                {
                    products.Add(v);
                }
                HttpContext.Session.SetObjectAsJson("cart", products);
            }
                ViewBag.similar=dbcontext.products.Where(t=>t.Title.Contains(dbcontext.products.FirstOrDefault(h=>h.ProductId==m.ProductId).Title)).Where(n=>n.ProductId!=m.ProductId).ToList();
                ViewBag.purchases=products;
                ViewBag.product=product;
                HttpContext.Session.SetObjectAsJson("cart", products);
                return View("ViewProduct");
        }
        [Route("checkout")]
        [HttpGet]
        [Authorize(Roles="Level1")]
        public IActionResult Checkout()
        {
             ViewBag.purchases=HttpContext.Session.GetObjectFromJson<List<Product>>("cart");
            return View();
        }
        [Route("delete{productid}")]
        [HttpGet]
        public IActionResult Delete(int productid)
        {
            List<Product> updatedproducts=new List<Product>();

            foreach (var product in HttpContext.Session.GetObjectFromJson<List<Product>>("cart"))
            {
                if(product.ProductId!=productid)
                {
                    updatedproducts.Add(product);
                }
            }
            ViewBag.purchases=updatedproducts;
            HttpContext.Session.SetObjectAsJson("cart", updatedproducts);

            return RedirectToAction("Checkout");
        }
    }
}

