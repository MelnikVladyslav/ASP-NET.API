using DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class StoreDbContext5 : IdentityDbContext
    {
        public StoreDbContext5(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Laptop>().HasOne(p => p.Memory)
                                        .WithMany(c => c.Laptops)
                                        .HasForeignKey(p => p.MemoryId);

            modelBuilder.SeedColors();
            modelBuilder.SeedPhones();
        }

        public virtual DbSet<Laptop> Laptops { get; set; }
        public virtual DbSet<Memory> Memories { get; set; }
    }
}