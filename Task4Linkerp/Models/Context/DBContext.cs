using Microsoft.EntityFrameworkCore;
using Task4Linkerp.Models.Domian;

namespace Task4Linkerp.Models.Context
{
    public class DBContext : DbContext
    {

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }

        public DbSet<Borrower> Borrowers { get; set; }

        public DbSet<Borrowed> Borroweds { get; set; }

    }
}
