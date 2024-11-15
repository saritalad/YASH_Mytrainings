using Microsoft.EntityFrameworkCore;
namespace WebAPI_AZure.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
