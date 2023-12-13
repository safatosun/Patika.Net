using Microsoft.EntityFrameworkCore;
using week4_homeworks;

namespace week4_homeworks.DBOperations
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        { }
        public DbSet<Book> Books { get; set; }

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
                    GenreId = 1, // Personal Growth
                    PageCount = 200,
                    PublishDate = new DateTime(2001, 06, 12)
                },
                new Book
                {
                    Id=2,
                    Title = "Herland",
                    GenreId = 2, // Science Fiction
                    PageCount = 250,
                    PublishDate = new DateTime(2002, 05, 19)
                },
               new Book
                {
                    Id=3,
                    Title = "Dune",
                    GenreId = 2, // Science Fiction
                    PageCount = 540,
                    PublishDate = new DateTime(2002, 12, 21)
               }
            );

        }
    }
}