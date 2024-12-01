using Crudstudent.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crudstudent.Web.Data
{
    public class ApplicationDbContext: DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }
}
