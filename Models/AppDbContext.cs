using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailAPI.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<ProductInfo> ProductInfo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Category Table
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Fruits" });
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 2, CategoryName = "Vegetables" });
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 3, CategoryName = "Poultry" });

            //Seed Status Table
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusID = 1, StatusName = "Sold" });
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusID = 2, StatusName = "InStock" });
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusID = 3, StatusName = "Damaged" });


            // Seed Product Table
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 1,
                ProductName = "Apples",
                Barcode = "11111",
                Description = "Apples",
                Weight = 10,
                StatusID = 1,
                CategoryID = 1,
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 2,
                ProductName = "Oranges",
                Barcode = "22222",
                Description = "Oranges",
                Weight = 12,
                StatusID = 2,
                CategoryID = 1,
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 3,
                ProductName = "Grapes",
                Barcode = "33333",
                Description = "Grapes",
                Weight = 2,
                StatusID = 3,
                CategoryID = 1,
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 4,
                ProductName = "Carrots",
                Barcode = "44444",
                Description = "Carrots",
                Weight = 5,
                StatusID = 1,
                CategoryID = 2,
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 5,
                ProductName = "Cucumber",
                Barcode = "55555",
                Description = "Cucumber",
                Weight = 15,
                StatusID = 2,
                CategoryID = 2,
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 6,
                ProductName = "Eggs",
                Barcode = "66666",
                Description = "Eggs",
                Weight = 20,
                StatusID = 1,
                CategoryID = 3,
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 7,
                ProductName = "Meat",
                Barcode = "77777",
                Description = "Meat",
                Weight = 18,
                StatusID = 2,
                CategoryID = 3,
            });

            //Seed Users Table
            var ph = new PasswordHasher<IdentityUser>();
            var user1 = new IdentityUser
            {
                Id = "1",
                UserName = "retailapi",
                NormalizedUserName = "retailapi".ToUpper(),
                Email = "retailapi@gmail.com",
                EmailConfirmed = true
            };
            user1.PasswordHash = ph.HashPassword(user1, "Retailapi123");
             modelBuilder.Entity<IdentityUser>().HasData(user1);

            //Seed Roles Table
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "admin_role",
                    Name = "admin",
                    NormalizedName = "admin".ToUpper(),
                });

            //Seed UserRoles Table
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
               new IdentityUserRole<string>
               {
                   RoleId = "admin_role",
                   UserId = "1"
               });
        }
    }
}
