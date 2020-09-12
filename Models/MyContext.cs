using System;
using Commercial.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
namespace Commercial.Models
{
public class MyContext : IdentityDbContext<User>
    {
        public MyContext(DbContextOptions<MyContext> options): base(options)
        {
            
        }
        public Microsoft.EntityFrameworkCore.DbSet<User> customers {get; set;}
        public Microsoft.EntityFrameworkCore.DbSet<Product> products {get; set;}
        public Microsoft.EntityFrameworkCore.DbSet<Order> orders {get; set;}
                
    }
    
}