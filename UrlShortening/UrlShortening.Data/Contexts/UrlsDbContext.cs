using Microsoft.EntityFrameworkCore;

namespace UrlShortening.Data.Contexts
{
    public class UrlsDbContext : DbContext
    {
        public UrlsDbContext(DbContextOptions<UrlsDbContext> options) : base(options)
        {
        }

        public DbSet<Url> Urls { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UrlConfiguration());
        }
    }
}