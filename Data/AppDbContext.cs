using Core.Models;
using Data.Configuration;
using Data.Seed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Persons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] {1,2}));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[]{1,2}));
            modelBuilder.Entity<Person>().HasKey(x => x.Id);  // burasıda ayrı klasör oluşturmadan confügüre ettiğimi yer
            modelBuilder.Entity<Person>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<Person>().Property(x => x.Name).HasMaxLength(100);
            modelBuilder.Entity<Person>().Property(x => x.SurName).HasMaxLength(100);
        }
    }
}
