using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sofomo.Models;

namespace Sofomo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { 

        }
        public DbSet<IpInfo> IpInfos { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Language> Languages{get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IpInfo>(entity =>
            {
                entity.HasKey(i => i.Id);
                entity.Property(i => i.Id).ValueGeneratedOnAdd();
            });
            builder.Entity<Location>(entity =>
            {
                entity.HasKey(i => i.Id);
                entity.Property(i => i.Id).ValueGeneratedOnAdd();
                entity.HasOne(p => p.IpInfo).WithOne(l => l.Location);

            });
            builder.Entity<Language>(entity =>
            {
                entity.HasKey(i => i.Id);
                entity.Property(i => i.Id).ValueGeneratedOnAdd();
                entity.HasOne(i => i.Location).WithMany(p => p.Languages).HasForeignKey(p => p.LocationId);

            });
        }
    }
}
