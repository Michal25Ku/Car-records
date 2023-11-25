using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CarDbContext : DbContext
    {
        public DbSet<CarEntity> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"data source=d:\Cars.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarEntity>()
                .HasKey(e => e.CarId);

            modelBuilder.Entity<CarEntity>()
                .HasData(
                new CarEntity()
                {
                    CarId = 1,
                    Model = "Felicia",
                    Producer = "Skoda",
                    EnginePower = 100,
                    LicensePlateNumber = "KR 90L",
                    Priority = 1,
                },
                new CarEntity()
                {
                    CarId = 2,
                    Model = "Golf 2",
                    Producer = "Wolkswagen",
                    EngineCapacity = "1.6",
                    EnginePower = 120,
                    LicensePlateNumber = "KR 17K",
                    Priority = 2,
                    Created = new DateTime(2000, 10, 10)
                }
            );
        }
    }
}
