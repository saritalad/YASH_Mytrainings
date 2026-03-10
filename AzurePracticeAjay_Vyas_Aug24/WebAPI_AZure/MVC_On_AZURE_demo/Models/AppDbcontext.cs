using Microsoft.EntityFrameworkCore;

namespace MVC_On_AZURE_demo.Models
{
    public class AppDbcontext:DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext>options):base(options) { }
       
        public DbSet<Student> Student { get; set; }
    }
}
