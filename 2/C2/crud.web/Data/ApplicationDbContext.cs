using crud.web.Models;
using Microsoft.EntityFrameworkCore;

namespace crud.web.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}
