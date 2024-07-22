using Microsoft.EntityFrameworkCore;
using RealTimeDataApp.Domain.Entities;

namespace RealTimeDataApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<DataModel> DataModels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DataModel>().ToTable("DataModels");
            modelBuilder.Entity<DataModel>().HasKey(x => x.Id);
        }
    }
}