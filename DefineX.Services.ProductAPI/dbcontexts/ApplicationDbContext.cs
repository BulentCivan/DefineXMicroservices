using DefineX.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Buffers.Text;

namespace DefineX.Services.ProductAPI.dbcontexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Image> ProductImages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                id = 1,
                Title = "Black T-Shirt For Woman",
                Description = "Vivamus suscipit tortor eget felis porttitor volutpat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin eget tortor risus. Nulla porttitoraccumsan tincidunt. Pellentesque in ipsum id orci porta dapibus.",
                Type = "fashion",
                Brand = "nike",
                CategoryName = "Women",
                Collection = new[] { "YENİ GELEN ÜRÜNLER" },
                Price = 145,
                tags = new[] { "new", "s", "m", "yellow", "white" },
                IsHot = true,
                discount = "40",
                IsNew = true
            }, new Product
            {
                id = 2,
                Title = "T-Shirt Form Girls",
                Description = "Vivamus suscipit tortor eget felis porttitor volutpat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin eget tortor risus. Nulla porttitoraccumsan tincidunt. Pellentesque in ipsum id orci porta dapibus.",
                Type = "fashion",
                Brand = "geox",
                CategoryName = "Women",
                Collection = new[] { "TREND" },
                Price = 185,
                tags = new[] { "s", "m", "l", "olive", "navy" },
                IsHot = false,
                discount = "40",
                IsNew = false
            }, new Product
            {
                id = 3,
                Title = "White Black Line Dress",
                Description = "Vivamus suscipit tortor eget felis porttitor volutpat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin eget tortor risus. Nulla porttitoraccumsan tincidunt. Pellentesque in ipsum id orci porta dapibus.",
                Type = "fashion",
                Brand = "nike",
                CategoryName = "Women",
                Collection = new[] { "featured products" },
                Price = 174,
                tags = new[] { "nike", "l", "m", "red", "black" },
                IsHot = false,
                discount = "20",
                IsNew = true
            }, new Product
            {
                id = 4,
                Title = "Blue Dress For Woman",
                Description = "Vivamus suscipit tortor eget felis porttitor volutpat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin eget tortor risus. Nulla porttitoraccumsan tincidunt. Pellentesque in ipsum id orci porta dapibus.",
                Type = "fashion",
                Brand = "geox",
                CategoryName = "Women",
                Collection = new[] { "on sale" },
                Price = 98,
                tags = new[] { "s", "l", "green", "skyblue", "geox" },
                IsHot = true,
                discount = "0",
                IsNew = false
            }, new Product
            {
                id = 5,
                Title = "Black T-Shirt For Woman",
                Description = "Vivamus suscipit tortor eget felis porttitor volutpat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin eget tortor risus. Nulla porttitoraccumsan tincidunt. Pellentesque in ipsum id orci porta dapibus.",
                Type = "fashion",
                Brand = "biba",
                CategoryName = "Women",
                Collection = new[] { "featured products" },
                Price = 230,
                tags = new[] { "m", "l", "green", "black", "biba" },
                IsHot = false,
                discount = "0",
                IsNew = true
            }, new Product
            {
                id = 6,
                Title = "Blue Dress For Woman",
                Description = "Vivamus suscipit tortor eget felis porttitor volutpat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin eget tortor risus. Nulla porttitoraccumsan tincidunt. Pellentesque in ipsum id orci porta dapibus.",
                Type = "fashion",
                Brand = "max",
                CategoryName = "Women",
                Collection = new[] { "EN ÇOK SATANLAR" },
                Price = 121,
                tags = new[] { "new", "s", "m", "olive", "gray" },
                IsHot = false,
                discount = "40",
                IsNew = true
            },
            new Product
            {
                id = 12,
                Title = "boho tops",
                Description = "Vivamus suscipit tortor eget felis porttitor volutpat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin eget tortor risus. Nulla porttitoraccumsan tincidunt. Pellentesque in ipsum id orci porta dapibus.",
                Type = "fashion",
                Brand = "nike",
                CategoryName = "Women",
                Collection = new[] { "best sellers", "on sale" },
                Price = 129,
                tags = new[] { "xs", "s", "m", "red", "pink" },
                IsHot = false,
                discount = "40",
                IsNew = false
            }
            );


            modelBuilder.Entity<Variant>().HasData(

              new Variant { variant_id = 101, id = 1, sku = "sku1", size = "s", color = "yellow", image_id = 111 },
    new Variant { variant_id = 102, id = 1, sku = "sku2", size = "s", color = "white", image_id = 112 },
    new Variant { variant_id = 201, id = 2, sku = "sku1", size = "s", color = "olive", image_id = 211 },
    new Variant { variant_id = 202, id = 2, sku = "sku2", size = "s", color = "navy", image_id = 212 },
       new Variant { variant_id = 301, id = 3, sku = "sku3", size = "l", color = "red", image_id = 311 },
    new Variant { variant_id = 302, id = 3, sku = "skul3", size = "m", color = "red", image_id = 311 },
      new Variant { variant_id = 401, id = 4, sku = "sku4", size = "s", color = "green", image_id = 411 },
    new Variant { variant_id = 402, id = 4, sku = "skul4", size = "l", color = "green", image_id = 411 },
        new Variant { variant_id = 501, id = 5, sku = "sku5", size = "m", color = "green", image_id = 511 },
    new Variant { variant_id = 502, id = 5, sku = "skul5", size = "l", color = "green", image_id = 511 },
       new Variant { variant_id = 601, id = 6, sku = "sku6", size = "s", color = "olive", image_id = 611 },
    new Variant { variant_id = 602, id = 6, sku = "skul6", size = "s", color = "gray", image_id = 612 },
       new Variant { variant_id = 1201, id = 12, sku = "sku12", size = "xs", color = "red", image_id = 1211 },
    new Variant { variant_id = 1202, id = 12, sku = "skul12", size = "xs", color = "pink", image_id = 1212 }
            );

            modelBuilder.Entity<Image>().HasData(
   new Image { variant_id = new[] { 101 }, id = 1, alt = "yellow", src = "1.png", image_id = 111 },
    new Image { variant_id = new[] { 102 }, id = 1, alt = "white", src = "2.png", image_id = 112 },
    new Image { variant_id = new[] { 201 }, id = 2, alt = "olive", src = "3.png", image_id = 211 },
    new Image { variant_id = new[] { 202 }, id = 2, alt = "navy", src = "4.png", image_id = 212 },
     new Image { variant_id = new[] { 301 }, id = 3, alt = "whredite", src = "5.png", image_id = 311 },
    new Image { variant_id = new[] { 302 }, id = 3, alt = "red", src = "6.png", image_id = 312 },
      new Image { variant_id = new[] { 401 }, id = 4, alt = "green", src = "7.png", image_id = 411 },
    new Image { variant_id = new[] { 403 }, id = 4, alt = "skyblue", src = "8.png", image_id = 412 },
     new Image { variant_id = new[] { 501 }, id = 5, alt = "green", src = "9.png", image_id = 511 },
    new Image { variant_id = new[] { 502 }, id = 5, alt = "black", src = "10.png", image_id = 512 },
       new Image { variant_id = new[] { 601 }, id = 6, alt = "olive", src = "11.png", image_id = 611 },
    new Image { variant_id = new[] { 602 }, id = 6, alt = "gray", src = "12.png", image_id = 612 },
     new Image { variant_id = new[] { 1201 }, id = 12, alt = "red", src = "8.png", image_id = 1211 },
    new Image { variant_id = new[] { 1202 }, id = 12, alt = "pink", src = "9.png", image_id = 1212 }
           );

        }
    }
}