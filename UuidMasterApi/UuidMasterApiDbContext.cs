using Microsoft.EntityFrameworkCore;
using UuidMasterApi.Entities;
using UuidMasterApi.Enums;

namespace UuidMasterApi
{
    public class UuidMasterApiDbContext : DbContext
    {
        public DbSet<Resource> Resources { get; set; } = null!;

        public UuidMasterApiDbContext(DbContextOptions<UuidMasterApiDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>()
                .HasData(
                new Resource(Source.FRONTEND, "Event", 1, 1)
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
