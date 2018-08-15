using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace gameStats.Models
{
    public partial class rawStatsContext : DbContext
    {
        public rawStatsContext()
        {
        }

        public rawStatsContext(DbContextOptions<rawStatsContext> options)
            : base(options)
        {
        }

        public DbSet<Players> Players { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Players>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nickname).IsRequired();
                entity.Property(e => e.Distance);
                entity.Property(e => e.Hits);
                entity.Property(e => e.Shots);
            });
        }
    }
}
