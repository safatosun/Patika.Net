using Microsoft.EntityFrameworkCore;
using week4_homeworks.Entities;

namespace week4_homeworks.DBOperations
{
    public class BookStoreDbContext : DbContext,IBookStoreDbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public override int SaveChanges()
        {
           return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "bookDatabase");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id=1,
                    Title = "Lean Startup",
                    GenreId = 1, 
                    PageCount = 200,
                    PublishDate = new DateTime(2001, 06, 12)
                },
                new Book
                {
                    Id=2,
                    Title = "Herland",
                    GenreId = 2, 
                    PageCount = 250,
                    PublishDate = new DateTime(2002, 05, 19)
                },
               new Book
                {
                    Id=3,
                    Title = "Dune",
                    GenreId = 2, 
                    PageCount = 540,
                    PublishDate = new DateTime(2002, 12, 21)
               }
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = 1,
                    Name= "Personel Growth",
                },
                new Genre
                {
                    Id = 2,
                    Name = "Science Fiction"
                },
                new Genre
                {
                    Id = 3,
                    Name = "Romance"
                }                   
                );
           
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    Name = "Turgut",
                    Surname ="Özakman",
                    Birthdate = new DateTime(2002, 12, 21)

                },
                new Author
                {
                    Id = 2,
                    Name = "Ýlber",
                    Surname = "Ortaylý",
                    Birthdate = new DateTime(2000, 12, 21)
                },
                new Author
                {
                    Id = 3,
                    Name = "Ali",
                    Surname = "Ýnceman",
                    Birthdate = new DateTime(1998, 12, 21)
                }
                );
        }
    }
}