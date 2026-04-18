using System.Data;
using Dapper;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HelloWorld.Data
{
    public class DataContextEF : DbContext
    {
        public DbSet<Computer> Computer{get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;",optionsBuilder=>optionsBuilder.EnableRetryOnFailure());
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TAppSchema");
            modelBuilder.Entity<Computer>()
            // .HasNoKey(); telling, “This entity DOES NOT have a primary key”
            .HasKey(c=>c.ComputerId);
            // .ToTable("TableName","SchemaName")
    
        
        }

    }
}
