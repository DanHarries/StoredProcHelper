using Microsoft.EntityFrameworkCore;
using System;

namespace StoredProcHelper.Data
{
    /// <summary>
    /// Db Context
    /// </summary>
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
           : base(options)
        {
        }

        // Add Tables and Stored Procs in here

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Any configuration options
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Any model creation overrides in here 
        }


    }
}
