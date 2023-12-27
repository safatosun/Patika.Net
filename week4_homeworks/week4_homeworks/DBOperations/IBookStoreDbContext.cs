using Microsoft.EntityFrameworkCore;
using week4_homeworks.Entities;

namespace week4_homeworks.DBOperations
{
    public interface IBookStoreDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Author> Authors { get; set; }

        int SaveChanges();

    }
}
