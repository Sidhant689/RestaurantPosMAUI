﻿using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestaurantPosMAUI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPosMAUI.Infrastructure
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            base.OnModelCreating(modelBuilder);

            #region Seeding Data
            modelBuilder.Entity<MenuCategory>().HasData(
            new MenuCategory { Id = 1, Name = "Beverages", Icon = "drink.png" },
            new MenuCategory { Id = 2, Name = "Main Course", Icon = "meal.png" },
            new MenuCategory { Id = 3, Name = "Snacks", Icon = "snacks.png" },
            new MenuCategory { Id = 4, Name = "Desserts", Icon = "cake.png" },
            new MenuCategory { Id = 5, Name = "Fast Food", Icon = "fast_food.png" }
        );

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { Id = 1, Name = "Beer", Icon = "beer.png", Description = "Chilled beer", Price = 4.99m },
        new MenuItem { Id = 2, Name = "Biryani", Icon = "biryani.png", Description = "Spicy chicken biryani", Price = 7.99m },
        new MenuItem { Id = 3, Name = "Buns", Icon = "buns.png", Description = "Freshly baked buns", Price = 2.99m },
        new MenuItem { Id = 4, Name = "Burger and Fries Combo", Icon = "burger_fries_combo.png", Description = "Burger with fries", Price = 5.99m },
        new MenuItem { Id = 5, Name = "Cake", Icon = "cake.png", Description = "Delicious chocolate cake", Price = 3.99m },
        new MenuItem { Id = 6, Name = "Chocolate", Icon = "chocolate.png", Description = "Rich chocolate bar", Price = 1.99m },
        new MenuItem { Id = 7, Name = "Cocktail", Icon = "cocktail.png", Description = "Refreshing cocktail", Price = 6.99m },
        new MenuItem { Id = 8, Name = "Coffee", Icon = "coffee.png", Description = "Hot coffee", Price = 1.99m },
        new MenuItem { Id = 9, Name = "Cupcake", Icon = "cupcake.png", Description = "Sweet cupcake", Price = 2.49m },
        new MenuItem { Id = 10, Name = "Donut", Icon = "donut.png", Description = "Glazed donut", Price = 1.49m },
        new MenuItem { Id = 11, Name = "Energy Drink", Icon = "energy_drink.png", Description = "Energy drink", Price = 2.99m },
        new MenuItem { Id = 12, Name = "Fast Food", Icon = "fast_food.png", Description = "Quick and tasty fast food", Price = 5.99m },
        new MenuItem { Id = 13, Name = "Fish and Chips", Icon = "fish_and_chips.png", Description = "Crispy fish and chips", Price = 6.99m },
        new MenuItem { Id = 14, Name = "Fish", Icon = "fish.png", Description = "Grilled fish", Price = 7.99m },
        new MenuItem { Id = 15, Name = "French Fries", Icon = "french_fries.png", Description = "Crispy french fries", Price = 2.99m },
        new MenuItem { Id = 16, Name = "Fried Chicken", Icon = "fried_chicken.png", Description = "Crispy fried chicken", Price = 5.99m },
        new MenuItem { Id = 17, Name = "Fried Egg", Icon = "fried_egg.png", Description = "Sunny_side_up fried egg", Price = 1.49m },
        new MenuItem { Id = 18, Name = "Fried Rice", Icon = "fried_rice.png", Description = "Savory fried rice", Price = 4.99m },
        new MenuItem { Id = 19, Name = "Hamburger", Icon = "hamburger.png", Description = "Juicy hamburger", Price = 4.99m },
        new MenuItem { Id = 20, Name = "Hotdog", Icon = "hotdog.png", Description = "Grilled hotdog", Price = 3.49m },
        new MenuItem { Id = 21, Name = "Ice Cream", Icon = "ice_cream.png", Description = "Cold ice cream", Price = 2.99m },
        new MenuItem { Id = 22, Name = "Idli Platter", Icon = "idli_platter.png", Description = "South Indian idli platter", Price = 3.99m },
        new MenuItem { Id = 23, Name = "Kebab", Icon = "kebab.png", Description = "Grilled kebab", Price = 5.99m },
        new MenuItem { Id = 24, Name = "Kimchi Jjigae", Icon = "kimchi_jjiage.png", Description = "Spicy kimchi stew", Price = 6.99m },
        new MenuItem { Id = 25, Name = "Laddu", Icon = "laddu.png", Description = "Sweet laddu", Price = 1.99m },
        new MenuItem { Id = 26, Name = "Lobster", Icon = "lobster.png", Description = "Fresh lobster", Price = 15.99m },
        new MenuItem { Id = 27, Name = "Mango", Icon = "mango.png", Description = "Ripe mango", Price = 1.49m },
        new MenuItem { Id = 28, Name = "Masala Dosa", Icon = "masala_dosa.png", Description = "Crispy masala dosa", Price = 4.99m },
        new MenuItem { Id = 29, Name = "Meal", Icon = "meal.png", Description = "Complete meal", Price = 9.99m },
        new MenuItem { Id = 30, Name = "Nachos", Icon = "nachos.png", Description = "Cheesy nachos", Price = 3.99m },
        new MenuItem { Id = 31, Name = "Noodles", Icon = "noodles.png", Description = "Stir_fried noodles", Price = 4.99m },
        new MenuItem { Id = 32, Name = "Orange Juice", Icon = "orange_juice.png", Description = "Fresh orange juice", Price = 2.49m },
        new MenuItem { Id = 33, Name = "Pancakes", Icon = "pancakes.png", Description = "Fluffy pancakes", Price = 3.99m },
        new MenuItem { Id = 34, Name = "Paneer", Icon = "paneer.png", Description = "Paneer curry", Price = 4.99m },
        new MenuItem { Id = 35, Name = "Pasta", Icon = "pasta.png", Description = "Italian pasta", Price = 5.99m },
        new MenuItem { Id = 36, Name = "Pie", Icon = "pie.png", Description = "Fruit pie", Price = 3.99m },
        new MenuItem { Id = 37, Name = "Pizza Slice", Icon = "pizza_slice.png", Description = "Slice of pizza", Price = 2.99m },
        new MenuItem { Id = 38, Name = "Pizza", Icon = "pizza.png", Description = "Whole pizza", Price = 8.99m },
        new MenuItem { Id = 39, Name = "Ramen", Icon = "ramen.png", Description = "Japanese ramen", Price = 6.99m },
        new MenuItem { Id = 40, Name = "Rice", Icon = "rice.png", Description = "Steamed rice", Price = 1.99m },
        new MenuItem { Id = 41, Name = "Roasted Chicken", Icon = "roasted_chicken.png", Description = "Roasted chicken", Price = 7.99m },
        new MenuItem { Id = 42, Name = "Salad Bowl", Icon = "salad_bowl.png", Description = "Fresh salad bowl", Price = 4.99m },
        new MenuItem { Id = 43, Name = "Salad Plate", Icon = "salad_plate.png", Description = "Fresh salad plate", Price = 4.99m },
        new MenuItem { Id = 44, Name = "Samosa", Icon = "samosa.png", Description = "Crispy samosa", Price = 1.99m },
        new MenuItem { Id = 45, Name = "Sandwich", Icon = "sandwich.png", Description = "Tasty sandwich", Price = 3.99m },
        new MenuItem { Id = 46, Name = "Snacks", Icon = "snacks.png", Description = "Various snacks", Price = 2.99m },
        new MenuItem { Id = 47, Name = "Soda", Icon = "soda.png", Description = "Refreshing soda", Price = 1.49m },
        new MenuItem { Id = 48, Name = "Soft Drink", Icon = "soft_drink.png", Description = "Cold soft drink", Price = 1.99m },
        new MenuItem { Id = 49, Name = "Soju", Icon = "soju.png", Description = "Korean soju", Price = 3.99m },
        new MenuItem { Id = 50, Name = "Spaghetti", Icon = "spaghetti.png", Description = "Italian spaghetti", Price = 5.99m },
        new MenuItem { Id = 51, Name = "Sushi", Icon = "sushi.png", Description = "Assorted sushi", Price = 8.99m },
        new MenuItem { Id = 52, Name = "Taco", Icon = "taco.png", Description = "Mexican taco", Price = 3.99m },
        new MenuItem { Id = 53, Name = "Thai Food", Icon = "thai_food.png", Description = "Spicy Thai food", Price = 6.99m },
        new MenuItem { Id = 54, Name = "Thali", Icon = "thali.png", Description = "Indian thali", Price = 7.99m },
        new MenuItem { Id = 55, Name = "Wrap", Icon = "wrap.png", Description = "Healthy wrap", Price = 4.99m }
                );

            modelBuilder.Entity<MenuItemCategoryMapping>().HasData(
    new MenuItemCategoryMapping { Id = 1, MenuCategoryId = 1, MenuId = 1 },
    new MenuItemCategoryMapping { Id = 2, MenuCategoryId = 1, MenuId = 6 },
    new MenuItemCategoryMapping { Id = 3, MenuCategoryId = 1, MenuId = 7 },
    new MenuItemCategoryMapping { Id = 4, MenuCategoryId = 1, MenuId = 8 },
    new MenuItemCategoryMapping { Id = 5, MenuCategoryId = 1, MenuId = 10 },
    new MenuItemCategoryMapping { Id = 6, MenuCategoryId = 1, MenuId = 11 },
    new MenuItemCategoryMapping { Id = 7, MenuCategoryId = 1, MenuId = 32 },
    new MenuItemCategoryMapping { Id = 8, MenuCategoryId = 1, MenuId = 47 },
    new MenuItemCategoryMapping { Id = 9, MenuCategoryId = 1, MenuId = 48 },
    new MenuItemCategoryMapping { Id = 10, MenuCategoryId = 1, MenuId = 49 },
    new MenuItemCategoryMapping { Id = 11, MenuCategoryId = 2, MenuId = 2 },
    new MenuItemCategoryMapping { Id = 12, MenuCategoryId = 2, MenuId = 13 },
    new MenuItemCategoryMapping { Id = 13, MenuCategoryId = 2, MenuId = 14 },
    new MenuItemCategoryMapping { Id = 14, MenuCategoryId = 2, MenuId = 18 },
    new MenuItemCategoryMapping { Id = 15, MenuCategoryId = 2, MenuId = 20 },
    new MenuItemCategoryMapping { Id = 16, MenuCategoryId = 2, MenuId = 22 },
    new MenuItemCategoryMapping { Id = 17, MenuCategoryId = 2, MenuId = 23 },
    new MenuItemCategoryMapping { Id = 18, MenuCategoryId = 2, MenuId = 24 },
    new MenuItemCategoryMapping { Id = 19, MenuCategoryId = 2, MenuId = 26 },
    new MenuItemCategoryMapping { Id = 20, MenuCategoryId = 2, MenuId = 28 },
    new MenuItemCategoryMapping { Id = 21, MenuCategoryId = 2, MenuId = 29 },
    new MenuItemCategoryMapping { Id = 22, MenuCategoryId = 2, MenuId = 31 },
    new MenuItemCategoryMapping { Id = 23, MenuCategoryId = 2, MenuId = 34 },
    new MenuItemCategoryMapping { Id = 24, MenuCategoryId = 2, MenuId = 35 },
    new MenuItemCategoryMapping { Id = 25, MenuCategoryId = 2, MenuId = 38 },
    new MenuItemCategoryMapping { Id = 26, MenuCategoryId = 2, MenuId = 39 },
    new MenuItemCategoryMapping { Id = 27, MenuCategoryId = 2, MenuId = 40 },
    new MenuItemCategoryMapping { Id = 28, MenuCategoryId = 2, MenuId = 41 },
    new MenuItemCategoryMapping { Id = 29, MenuCategoryId = 2, MenuId = 45 },
    new MenuItemCategoryMapping { Id = 30, MenuCategoryId = 2, MenuId = 50 },
    new MenuItemCategoryMapping { Id = 31, MenuCategoryId = 2, MenuId = 51 },
    new MenuItemCategoryMapping { Id = 32, MenuCategoryId = 2, MenuId = 52 },
    new MenuItemCategoryMapping { Id = 33, MenuCategoryId = 2, MenuId = 53 },
    new MenuItemCategoryMapping { Id = 34, MenuCategoryId = 2, MenuId = 54 },
    new MenuItemCategoryMapping { Id = 35, MenuCategoryId = 2, MenuId = 55 },
    new MenuItemCategoryMapping { Id = 36, MenuCategoryId = 3, MenuId = 3 },
    new MenuItemCategoryMapping { Id = 37, MenuCategoryId = 3, MenuId = 15 },
    new MenuItemCategoryMapping { Id = 38, MenuCategoryId = 3, MenuId = 16 },
    new MenuItemCategoryMapping { Id = 39, MenuCategoryId = 3, MenuId = 17 },
    new MenuItemCategoryMapping { Id = 40, MenuCategoryId = 3, MenuId = 19 },
    new MenuItemCategoryMapping { Id = 41, MenuCategoryId = 3, MenuId = 30 },
    new MenuItemCategoryMapping { Id = 42, MenuCategoryId = 4, MenuId = 5 },
    new MenuItemCategoryMapping { Id = 43, MenuCategoryId = 4, MenuId = 8 },
    new MenuItemCategoryMapping { Id = 44, MenuCategoryId = 4, MenuId = 9 },
    new MenuItemCategoryMapping { Id = 45, MenuCategoryId = 4, MenuId = 21 },
    new MenuItemCategoryMapping { Id = 46, MenuCategoryId = 4, MenuId = 25 },
    new MenuItemCategoryMapping { Id = 47, MenuCategoryId = 4, MenuId = 27 },
    new MenuItemCategoryMapping { Id = 48, MenuCategoryId = 4, MenuId = 33 },
    new MenuItemCategoryMapping { Id = 49, MenuCategoryId = 4, MenuId = 36 },
    new MenuItemCategoryMapping { Id = 50, MenuCategoryId = 5, MenuId = 4 },
    new MenuItemCategoryMapping { Id = 51, MenuCategoryId = 5, MenuId = 12 },
    new MenuItemCategoryMapping { Id = 52, MenuCategoryId = 5, MenuId = 37 },
    new MenuItemCategoryMapping { Id = 53, MenuCategoryId = 5, MenuId = 38 },
    new MenuItemCategoryMapping { Id = 54, MenuCategoryId = 5, MenuId = 45 },
    new MenuItemCategoryMapping { Id = 55, MenuCategoryId = 5, MenuId = 46 }
);
            #endregion
        }

        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuItemCategoryMapping> MenuItemCategoriesMapping { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }

}
