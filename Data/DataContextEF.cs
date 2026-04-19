using System.Data;
using Dapper;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Data
{
    public class DataContextEF : DbContext
    {
        private IConfiguration _config;

        public DataContextEF(IConfiguration config)
        {
            _config=config;
        }
        public DbSet<Computer> Computer{get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"),optionsBuilder=>optionsBuilder.EnableRetryOnFailure());
           
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
