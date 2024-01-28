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
                .HasKey(e => e.CarId);

            modelBuilder.Entity<CarEntity>()
                .OwnsOne(c => c.ContactDetails);
        }
    }
}
