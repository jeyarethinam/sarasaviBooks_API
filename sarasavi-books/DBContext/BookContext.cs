using Microsoft.EntityFrameworkCore;
using sarasavi_books.Models;

namespace sarasavi_books.DBContext
{
    public class BookContext : DbContext
    {

        public BookContext(DbContextOptions<BookContext> options)
        : base(options)
        {
        }

        public DbSet<Book> books { get; set; } = null!;

    }
}
