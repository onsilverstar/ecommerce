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
    public class AdminstrationController : Controller
    {
        private MyContext dbcontext;
        private readonly RoleManager<IdentityRole> roleManager;
        
     public AdminstrationController(MyContext context, RoleManager<IdentityRole> _roleManager)
        {
            dbcontext=context;
            roleManager=_roleManager;
        }
        [Route("roles")]
        [HttpGet]
        public IActionResult Roles()
        {
            return View();
        }
        [Route("createroles")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(UserRoles mymodel)
        {
            if(ModelState.IsValid)
            {
                IdentityRole newuser=new IdentityRole{Name=mymodel.RoleName};
                IdentityResult newresult=await roleManager.CreateAsync(newuser);
                if (newresult.Succeeded)
                {
                    return RedirectToAction ("Dashboard", "Home");
                }
                foreach(IdentityError error in newresult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View("Roles", mymodel);
        }
    }
    
}