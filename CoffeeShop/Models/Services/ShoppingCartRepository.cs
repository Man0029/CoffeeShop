﻿using CoffeeShop.Data;
using CoffeeShop.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace CoffeeShop.Models.Services
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private CoffeeshopDbContext dbContext;
        public ShoppingCartRepository(CoffeeshopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<ShoppingCartItem>? ShoppingCartItems { get; set; }
        public string? ShoppingCartId { set; get; }
        public static ShoppingCartRepository GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            CoffeeshopDbContext context = services.GetService<CoffeeshopDbContext>() ??
            throw new Exception("Error initializing coffeeshopdbcontext");
            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();
            session?.SetString("CartId", cartId);
            return new ShoppingCartRepository(context) { ShoppingCartId = cartId };
        }
        public void AddToCart(Product product)
        {
            var shoppingCartItem = dbContext.ShoppingCartItems.FirstOrDefault(s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Quantity = 1,
                };
                dbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Quantity++;
            }
            dbContext.SaveChanges();
        }
        public void ClearCart()
        {
            var cartItems = dbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId);
            dbContext.ShoppingCartItems.RemoveRange(cartItems);
            dbContext.SaveChanges();
        }
        public List<ShoppingCartItem> GetAllShoppingCartItems()
        {
            return ShoppingCartItems ??= dbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId).Include(p => p.Product).ToList();
        }
        public decimal GetShoppingCartTotal()
        {
            var totalCost = dbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId).Select(s => s.Product.Price * s.Quantity).Sum();
            return totalCost;
        }
        public int RemoveFromCart(Product product)
        {
            var shoppingCartItem = dbContext.ShoppingCartItems.FirstOrDefault(s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);
            var quantity = 0;
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                    quantity = shoppingCartItem.Quantity;
                }
                else
                {
                    dbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            dbContext.SaveChanges();
            return quantity;
        }
    }
}
