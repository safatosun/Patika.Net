using Microsoft.EntityFrameworkCore;
using MovieStoreApp.Entities;


namespace MovieStoreApp.DBOperations
{
    public class MovieStoreDbContext : DbContext,IMovieStoreDbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options)
        {
                
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorMovie> ActorMovie { get; set; }
        public DbSet<Customer> Customers { get; set; }  
        public DbSet<Director> Directors { get; set; }
        public DbSet<FavoriteGenre> FavoriteGenre { get; set; }
        public DbSet<Genre> Genres { get; set; }    
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Order> Orders { get; set; }

        public int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "movieDatabase");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().HasData(

             new Actor { Id = 1, Name = "Buddy", SurName = "Hackett" },
             new Actor { Id = 2, Name = "Todd", SurName = "Haberkorn" },
             new Actor { Id = 3, Name = "Bill", SurName = "Hader" },
             new Actor { Id = 4, Name = "Lukas", SurName = "Haas" }
            );

            modelBuilder.Entity<ActorMovie>().HasData(

             new ActorMovie { Id = 1, ActorId = 1, MovieId = 1 },
             new ActorMovie { Id = 2, ActorId = 2, MovieId = 2 },
             new ActorMovie { Id = 3, ActorId = 3, MovieId = 3 },
             new ActorMovie { Id = 4, ActorId = 3, MovieId = 2 }
            );

            modelBuilder.Entity<Genre>().HasData(

              new Genre { Id = 1, Name = "Action" },
              new Genre { Id = 2, Name = "Comedy" },
              new Genre { Id = 3, Name = "Drama" },
              new Genre { Id = 4, Name = "Fantasy" }
            );

            modelBuilder.Entity<Director>().HasData(

              new Director { Id = 1, Name = "Alfred", Surname = "Hitchcock" },
              new Director { Id = 2, Name = "Orson", Surname = "Welles" },
              new Director { Id = 3, Name = "John", Surname = "Ford" },
              new Director { Id = 4, Name = "Howard", Surname = "Hawks" }
            );

            modelBuilder.Entity<Movie>().HasData(

                 new Movie
                 {
                     Id = 1,
                     Name = "The Godfather",
                     GenreId = 1,
                     DirectorId = 1,
                     Price = 30,
                     PublishDate = new DateTime(1972, 1, 1),
                     IsActive = true,
                 },
                new Movie
                {
                    Id = 2,
                    Name = "The Godfather 2",
                    GenreId = 2,
                    DirectorId = 2,
                    Price = 30,
                    PublishDate = new DateTime(1974, 1, 1),
                    IsActive = true,
                },
                new Movie
                {
                    Id = 3,
                    Name = "Citizen Kane",
                    GenreId = 3,
                    DirectorId = 3,
                    Price = 20,
                    PublishDate = new DateTime(1941, 1, 1),
                    IsActive = true,
                },
                new Movie
                {
                    Id = 4,
                    Name = "La Dolce Vita",
                    GenreId = 4,
                    DirectorId = 4,
                    Price = 10,
                    PublishDate = new DateTime(1960, 1, 1),
                    IsActive = true,
                }
            );

            modelBuilder.Entity<Customer>().HasData(

                 new Customer
                 {
                    Id = 1,
                    Name ="Ali",
                    Surname ="ince",
                    Email="ali@gmail.com",
                    Password="123456",
                 }               
            );

            modelBuilder.Entity<Order>().HasData(

                 new Order
                 {
                     Id = 1,
                     CustomerId = 1,    
                     MovieId = 1,
                     Price=30,
                     OrderTime = DateTime.Now 
                 }
            );

        }
    }
}
