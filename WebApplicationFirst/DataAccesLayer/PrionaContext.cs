
using Microsoft.EntityFrameworkCore;
using WebApplicationFirst.Models;

namespace WebApplicationFirst.DataAccesLayer
{
    public class PrionaContext : DbContext
    {
        public PrionaContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Category>Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=DESKTOP-MPV3150;Database=PrionaFb;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(options); 
        }
    }
}
