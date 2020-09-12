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
namespace Commercial.Controllers
{
    public class AccountController : Controller
    {
        private MyContext dbcontext;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        public AccountController(MyContext context, SignInManager<User> _signInManager, UserManager<User> _userManager)
        {
            dbcontext=context;
            signInManager=_signInManager;
            userManager=_userManager;
            
        }
        [Route("Account/Login")]
        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            if (ModelState.IsValid)
            {
                var result=await signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent:false, lockoutOnFailure: true);
                if(result.Succeeded)
                {

                    return RedirectToAction("Checkout", "Home", model);
                }
                
                    ModelState.AddModelError(string.Empty, "Invalid Login");
                
            }
            return View();
            
        }
        [Route("Account/Register")]
        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            if (ModelState.IsValid)
            {
                User newuser=new User {UserName=model.UserName, Email=model.Email,EmailConfirmed=model.EmailConfirmed, Password=model.Password};
                IdentityResult result=await userManager.CreateAsync(newuser, model.Password);
                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(newuser, "Level1");
                    return RedirectToAction("Checkout", "Home", model); 
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                
            }
            return RedirectToAction("Checkout", "Home", model);
            
        }
        private Task<User> GetCurrentUserAsync()
        {
            return userManager.GetUserAsync(HttpContext.User);
        }
        [Route("Account/Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [Route("Register")]
        [HttpGet]
        public IActionResult RegisterAccount()
        {
            return View("Register");
        }
       [Route("processorders")]
       [HttpPost]
        public IActionResult ProcessOrder(Order v)
        {
            var myorder=new Order();
            myorder.customer=dbcontext.Users.FirstOrDefault(k=>k.UserName==User.Identity.Name);
            myorder.Address = v.Address;
            myorder.Address2 = v.Address2;
            myorder.City = v.City;
            myorder.FirstName = v.FirstName;
            myorder.LastName = v.LastName;
            myorder.State = v.State;
            myorder.ZipCode = v.ZipCode;
        
                dbcontext.orders.Update(myorder);
                dbcontext.SaveChanges();
                

            return RedirectToAction("Dashboard", "Home");
        }

        
    }
    
}