using Microsoft.EntityFrameworkCore;

namespace MusicDBPlayground.DiscogsIntegration.Data;

public class DiscogsDbContext : DbContext
{
   public DbSet<OAuthTokenEntity> OAuthTokens { get; set; }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      optionsBuilder.UseSqlite("Data Source=discogs.db");
   }
}