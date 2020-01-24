using Microsoft.EntityFrameworkCore;
using System;
using CBD2303.Models;
namespace CBD2303
{
    public class MyDatabaseContext : DbContext
    {
        //public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options)
        //    : base(options)
        //{
        //}

        public DbSet<Users> Users { get; set; }
        public DbSet<Likes> Likes { get; set; }
        public DbSet<Relationships> Relationships { get; set; }
        public DbSet<StatusTexts> StatusTexts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=CBD2303FinalProject;user=sumanthdev;password=oneplus500");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Likes>().ToTable("Likes");
            modelBuilder.Entity<Relationships>().ToTable("Relationships");
            modelBuilder.Entity<StatusTexts>().ToTable("StatusTexts");
        }
    }
}
