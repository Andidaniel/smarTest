using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using SmarTest.DataLayer.Models;

namespace SmarTest.DataLayer
{
    public class SmarTestDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<StudentClass> Classes { get; set; }

        public SmarTestDbContext(DbContextOptions options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToCollection("Users");
            modelBuilder.Entity<StudentClass>().ToCollection("Classes");
        }
    }
}
