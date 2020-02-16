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
        public Microsoft.EntityFrameworkCore.DbSet<ShippingInformation> shippingdetails {get; set;}
        public Microsoft.EntityFrameworkCore.DbSet<Product> products {get; set;}
        public Microsoft.EntityFrameworkCore.DbSet<ShoppingCart> carts {get; set;}
        public Microsoft.EntityFrameworkCore.DbSet<CartItem> cartitems {get; set;}
       
     /* protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>()
           .HasOne(p => p.product)
            .WithMany(b => b.Buyers)
            .HasForeignKey(d =>d.ProductId )
            .HasConstraintName("ProductId_Product_Order");
     }*/
                
    }
    
}