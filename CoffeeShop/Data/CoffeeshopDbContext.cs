﻿using CoffeeShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace CoffeeShop.Data
{
    public class CoffeeshopDbContext : IdentityDbContext
    {
        public CoffeeshopDbContext(DbContextOptions<CoffeeshopDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "America",
                Price = 25,
                Detail = "Name product",
                ImageUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp",
                IsTrendingProduct = true,
            },
            new Product
            {
                Id = 2,
                Name = "Vietnam",
                Price = 20,
                Detail = "Vietnamese product",
                ImageUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp",
                IsTrendingProduct = true,
            },
            new Product
            {
                Id = 3,
                Name = "United Kingdom",
                Price = 15,
                Detail = "UK product",
                ImageUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp",
                IsTrendingProduct = true,
            },
            new Product
            {
                Id = 4,
                Name = "India",
                Price = 15,
                Detail = "India product",
                ImageUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp",
                IsTrendingProduct = true,
            },
            new Product
            {
                Id = 5,
                Name = "Russian",
                Price = 25,
                Detail = "Russian product",
                ImageUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp",
                IsTrendingProduct = true,
            },
            new Product
            {
                Id = 6,
                Name = "France",
                Price = 35,
                Detail = "France product",
                ImageUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp",
                IsTrendingProduct = true,
            }
            );
        }
    }
}
