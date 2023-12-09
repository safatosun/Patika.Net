using Microsoft.EntityFrameworkCore;
using PatikaRestfulApi.Entities.Models;

namespace PatikaRestfulApi.Repositories.EFCore
{
    public class RepositoryDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ProductDatabase");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Name = "Laptop",
                    Price = 2000
                },
                new Product()
                {
                    Id = 2,
                    Name = "Telefon",
                    Price = 1000
                },
                new Product()
                {
                    Id = 3,
                    Name = "Tablet",
                    Price = 800
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Name = "Admin",
                    Password = "1234"
                },
                new User()
                {
                    Id = 2,
                    Name = "User",
                    Password = "1234"
                }           
            );
        }
    }        
}
