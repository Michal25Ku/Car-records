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
        public DbSet<OwnerEntity> Owners { get; set; }
        private string DbPath { get; set; }

        public CarDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "cars.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"data source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarEntity>()
                .HasOne(e => e.Owner)
                .WithMany(c => c.Cars)
                .HasForeignKey(e => e.OwnerId);

            modelBuilder.Entity<OwnerEntity>()
                .HasMany(e => e.Cars);

            modelBuilder.Entity<OwnerEntity>().HasData
                (
                    new OwnerEntity()
                    {
                        Id = 1,
                        FirstName = "Jan",
                        LastName = "Nowak",
                        Pesel = "95715209461",
                        PhoneNumber = "+48923614982",
                        Email = "jan.nowak@gmail.com",
                    },
                    new OwnerEntity()
                    {
                        Id = 2,
                        FirstName = "Piotr",
                        LastName = "Kowalski",
                        Pesel = "12497432487",
                        PhoneNumber = "+48740981265",
                        Email = "piotr.kowalski@wp.pl",
                    }
                );

            modelBuilder.Entity<CarEntity>().HasData
                (
                    new CarEntity()
                    {
                        Id = 1,
                        Model = "Felicia",
                        Producer = "Skoda",
                        EngineCapacity = "1.3",
                        EnginePower = 60,
                        EngineType = "Benzynowy",
                        LicensePlateNumber = "KR AB12",
                        OwnerId = 1
                    },
                    new CarEntity()
                    {
                        Id = 2,
                        Model = "Golf 2",
                        Producer = "BMW",
                        EngineCapacity = "1.6",
                        EnginePower = 50,
                        EngineType = "Benzynowy",
                        LicensePlateNumber = "WI CB21",
                        State = 1,
                        OwnerId = 2
                    }
                );

            modelBuilder.Entity<OwnerEntity>()
                .OwnsOne(e => e.Address)
                .HasData
                (
                    new 
                    {
                        OwnerEntityId = 1,
                        City = "Kraków",
                        Street = "Krakowska 1",
                        PostalCode = "12-900",
                        Region = "Małopolska"
                    },
                    new 
                    {
                        OwnerEntityId = 2,
                        City = "Warszawa",
                        Street = "Warszawska 2",
                        PostalCode = "21-009",
                        Region = "Mazowsze"
                    }
                );
        }
    }
}
