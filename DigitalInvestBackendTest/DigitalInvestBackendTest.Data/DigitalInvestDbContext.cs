using DigitalInvestBackendTest.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DigitalInvestBackendTest.Data
{
    public class DigitalInvestDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

        public DbSet<Investor> Investors { get; set; }

        public DbSet<Funding> Fundings { get; set; }

        /// <summary>
        /// Default constructor, initializes an instance of <see cref="DigitalInvestDbContext"/>
        /// </summary>
        public DigitalInvestDbContext()
        {

        }

        /// <summary>
        /// Constructor, initializes an instance of <see cref="DigitalInvestDbContext"/>
        /// </summary>
        /// <param name="dbContextOptions"></param>
        public DigitalInvestDbContext(DbContextOptions<DigitalInvestDbContext> dbContextOptions) :
            base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
