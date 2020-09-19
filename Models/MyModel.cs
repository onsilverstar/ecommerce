using System;
using System.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Commercial.Models;
namespace Commercial.Models
{
    public class User: IdentityUser
    {
        public string Name {get; set;}
        public DateTime CreatedAt {get; set;}
        [NotMapped]
        [DataType(DataType.Password)]
        public string Password {get; set;}
          
    }
     public class Order
    {
        [Key]
        public int OrderId {get; set;}
        public int ProductId {get; set;}
        public List<Product> products {get; set;}
        public User customer {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Address {get; set;}
        public string Address2 {get; set;}
        public string City {get; set;}
        public string ZipCode {get; set;}
        public string State {get; set;}
        public int Quantity {get; set;}
        public bool Paid {get; set;}
        public float Cost {get; set;}
    }
    public class UserProduct
    {
        public User customer {get; set;}
        public Product product {get; set;}
    }
    
    public class Product
    {
        [Key]
        public int ProductId {get; set;}
        public int InitialQuantity {get; set;}
        public int Price {get; set;}
        public string Title {get; set;}
        public string Image {get; set;}
        public string Description {get; set;}
        public List<Categorized> categorization {get; set;}
        
        [NotMapped]
        public int Quantity {get; set;}
        [NotMapped]
        public IFormFile photo { get; set; }
    }

    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Title {get; set;}
        public List<Categorized> categorization { get; set; }
}

    public class Categorized
    {
        [Key]
        public int CategorizedId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public Product product { get; set; }
        public Category category { get; set; }
}

   
    public class UserRoles
    {
        [Required]
        public string RoleName {get; set;}
    }

}