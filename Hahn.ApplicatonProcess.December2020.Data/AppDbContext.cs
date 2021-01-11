using Microsoft.EntityFrameworkCore;
using Hahn.ApplicatonProcess.December2020.Core.Models;

namespace Hahn.ApplicatonProcess.December2020.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase("HagnHR");
        //}
        public DbSet<Applicant> Applicants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicant>().HasKey(c => c.Id);
        }
    }
}
