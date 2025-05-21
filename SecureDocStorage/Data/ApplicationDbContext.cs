using Microsoft.EntityFrameworkCore;
using SecureDocStorage.Models;

namespace SecureDocStorage.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}
