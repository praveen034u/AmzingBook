using IssueManagementService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IssueManagementService.Repositories
{
    public class IssueDbContext : DbContext
    {
        public IssueDbContext(DbContextOptions<IssueDbContext> options) : base(options) { }

        public DbSet<Issue> Issues { get; set; }
    }
}
