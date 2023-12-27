
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Models;
namespace Laba4.DataBase
{
    public class CarDealerDB : DbContext
    {
        public CarDealerDB(DbContextOptions<CarDealerDB> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<Mark> Marks { get; set; } = null!;
        public DbSet<Model> models { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Personalnumber> Personalnumbers { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
        }
    }
}
