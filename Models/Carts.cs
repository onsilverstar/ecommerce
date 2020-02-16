using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Commercial.Models;
namespace Commercial.Models
{
public class Cart
    {
        private MyContext _dbcontext;

        [Key]
        public string CartId {get; set;}
        public List<CartItem> purchases {get; set;}
    }
        
        
}
