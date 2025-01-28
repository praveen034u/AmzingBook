using BookManagementService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookManagementService.Repositories
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
