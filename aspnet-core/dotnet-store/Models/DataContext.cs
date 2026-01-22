using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
   public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().HasData(
            new List<Product>()
            {
            new Product() {Id = 1,ProductName = "Apple Watch 7",Price = 40000,IsActive = true,Image = "1.jpeg",IsHome = true,
            Description = "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Eius explicabo voluptatibus aperiam voluptate dignissimos expedita aspernatur similique vero exercitationem dicta, tempore repudiandae alias? Expedita, debitis ratione voluptates in fugiat exercitationem?"},
            new Product() {Id = 2,ProductName = "Apple Watch 8",Price = 50000,IsActive = true,Image = "2.jpeg",IsHome = false,
            Description = "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Eius explicabo voluptatibus aperiam voluptate dignissimos expedita aspernatur similique vero exercitationem dicta, tempore repudiandae alias? Expedita, debitis ratione voluptates in fugiat exercitationem?"},

            new Product() {Id = 3,ProductName = "Apple Watch 9",Price = 60000,IsActive = false,Image = "3.jpeg",IsHome = true,
            Description = "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Eius explicabo voluptatibus aperiam voluptate dignissimos expedita aspernatur similique vero exercitationem dicta, tempore repudiandae alias? Expedita, debitis ratione voluptates in fugiat exercitationem?"},
             new Product() {Id = 4,ProductName = "sApple Watch 10",Price = 70000,IsActive = false,Image = "4.jpeg",IsHome = true,
            Description = "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Eius explicabo voluptatibus aperiam voluptate dignissimos expedita aspernatur similique vero exercitationem dicta, tempore repudiandae alias? Expedita, debitis ratione voluptates in fugiat exercitationem?"},
            new Product() {Id = 5,ProductName = "Apsple Watch 11",Price = 80000,IsActive = true,Image = "5.jpeg",IsHome = false,
            Description = "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Eius explicabo voluptatibus aperiam voluptate dignissimos expedita aspernatur similique vero exercitationem dicta, tempore repudiandae alias? Expedita, debitis ratione voluptates in fugiat exercitationem?"},

            new Product() {Id = 6,ProductName = "Apple Watch 12",Price = 85000,IsActive = true,Image = "6.jpeg",IsHome = true,
            Description = "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Eius explicabo voluptatibus aperiam voluptate dignissimos expedita aspernatur similique vero exercitationem dicta, tempore repudiandae alias? Expedita, debitis ratione voluptates in fugiat exercitationem?"},
             new Product() {Id = 7,ProductName = "Apple Watch 13",Price = 90000,IsActive = true,Image = "7.jpeg",IsHome = false,
            Description = "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Eius explicabo voluptatibus aperiam voluptate dignissimos expedita aspernatur similique vero exercitationem dicta, tempore repudiandae alias? Expedita, debitis ratione voluptates in fugiat exercitationem?"},
            new Product() {Id = 8,ProductName = "Apple Watch 14",Price = 95000,IsActive = false,Image = "8.jpeg",IsHome = true,
            Description = "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Eius explicabo voluptatibus aperiam voluptate dignissimos expedita aspernatur similique vero exercitationem dicta, tempore repudiandae alias? Expedita, debitis ratione voluptates in fugiat exercitationem?"},
         });
    }
}