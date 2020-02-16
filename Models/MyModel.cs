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
     public class ShippingInformation
    {
        [Key]
        public string ShippingInformationId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Address {get; set;}
        public string Address2 {get; set;}
        public string City {get; set;}
        public string ZipCode {get; set;}
        public string State {get; set;}
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
        
        [NotMapped]
        public int Quantity {get; set;}
    }
    public class CartItem
    {
        
        [Key]
        public int CartItemId {get; set;}
        public string UserId {get; set;}
        [ForeignKey("Product")]
        public string ShoppingCartId {get; set;}
        public User customer {get; set;}
        public Product product {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Address {get; set;}
        public string Address2 {get; set;}
        public string City {get; set;}
        public string ZipCode {get; set;}
        public string State {get; set;}
        public int Quantity {get; set;}
       
    }
    public class ShoppingCart
    {
        private MyContext _dbcontext;
        public ShoppingCart(MyContext mycontext)
        {
            _dbcontext=mycontext;

        }
        public string ShoppingCartId {get; set; }
        public List<CartItem> MyCart {get; set;}
        public ShoppingCart GetCart(HttpContext services)
          {
    
            //ISession session=services.GetRequiredService<HttpContextAccessor>()?.HttpContext.Session;
            //var context = services.GetService<MyContext>();
            
            ISession session=services.Session;
            string cartid=session.GetString("CartId")??Guid.NewGuid().ToString();
            session.SetString("CartId", cartid);
            
            return  new ShoppingCart(_dbcontext){ShoppingCartId=cartid};
        }
        public ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        // Helper method to simplify shopping cart calls
       /*  public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart();
        }
         public string GetCartId(HttpContext context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }*/
        public void AddToCart(Product product, int quantity)
        {
            
            var cartitem=_dbcontext.cartitems
            .FirstOrDefault(n=>n.product.ProductId==product.ProductId && n.ShoppingCartId==ShoppingCartId);
            if (cartitem==null)
            {
                cartitem=new CartItem
                {ShoppingCartId=ShoppingCartId, product=product, Quantity=1};
                _dbcontext.cartitems.Add(cartitem);
            }
            
            else
            {
                cartitem.Quantity++;
            }
            _dbcontext.SaveChanges();
            
        }
        
        public List<CartItem> GetCartItems()
        {
            var ShoppingCartItems=
            _dbcontext.cartitems.Include(y=>y.product).
            Where(d=>d.ShoppingCartId==ShoppingCartId).ToList();
            return ShoppingCartItems;

        }
    }
    

        public class OrderItem+
    {
        public int Order  {get; set;}
        public string Customer {get; set;}
        public string Item {get; set;}
        public string Product {get; set;}
    }
    
    public class UserRoles
    {
        [Required]
        public string RoleName {get; set;}
    }

}