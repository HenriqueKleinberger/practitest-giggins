using Microsoft.EntityFrameworkCore;

namespace GigginsPractitestApi.Models
{
    public class GigginsPractitestApiContext : DbContext
    {
        public GigginsPractitestApiContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Giggin> Giggins { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Giggin>().ToTable("Giggins", c => c.IsTemporal());
        }
    }
}
