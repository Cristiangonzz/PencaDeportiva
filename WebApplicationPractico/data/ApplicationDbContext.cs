using Microsoft.EntityFrameworkCore;
using WebApplicationPractico.Models.Entity;

namespace WebApplicationPractico.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
    }
}
