using JuniorDotNet_TestTask.Models;
using Microsoft.EntityFrameworkCore;

namespace JuniorDotNet_TestTask.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<ProductionFacility> ProductionFacilities { get; set; }
        public DbSet<ProcessEquipmentType> ProcessEquipmentTypes { get; set; }
        public DbSet<EquipmentPlacementContract> EquipmentPlacementContracts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Данные для ProductionFacilities
            modelBuilder.Entity<ProductionFacility>().HasData(
                new ProductionFacility { Id = 1, Code = "FAC1", Name = "Factory 1", StandardArea = 5000 },
                new ProductionFacility { Id = 2, Code = "FAC2", Name = "Factory 2", StandardArea = 3000 },
                new ProductionFacility { Id = 3, Code = "FAC3", Name = "Factory 3", StandardArea = 4000 },
                new ProductionFacility { Id = 4, Code = "FAC4", Name = "Factory 4", StandardArea = 7000 },
                new ProductionFacility { Id = 5, Code = "FAC5", Name = "Factory 5", StandardArea = 2500 },
                new ProductionFacility { Id = 6, Code = "FAC6", Name = "Factory 6", StandardArea = 8000 },
                new ProductionFacility { Id = 7, Code = "FAC7", Name = "Factory 7", StandardArea = 3500 },
                new ProductionFacility { Id = 8, Code = "FAC8", Name = "Factory 8", StandardArea = 6000 },
                new ProductionFacility { Id = 9, Code = "FAC9", Name = "Factory 9", StandardArea = 4500 },
                new ProductionFacility { Id = 10, Code = "FAC10", Name = "Factory 10", StandardArea = 10000 }
            );

            // Данные для ProcessEquipmentTypes
            modelBuilder.Entity<ProcessEquipmentType>().HasData(
                new ProcessEquipmentType { Id = 1, Code = "EQ1", Name = "Type 1 Small Equipment", Area = 50 },
                new ProcessEquipmentType { Id = 2, Code = "EQ2", Name = "Type 2 Compact Equipment", Area = 30 },
                new ProcessEquipmentType { Id = 3, Code = "EQ3", Name = "Type 3 Large Equipment", Area = 70 },
                new ProcessEquipmentType { Id = 4, Code = "EQ4", Name = "Type 4 Extra Large", Area = 120 },
                new ProcessEquipmentType { Id = 5, Code = "EQ5", Name = "Type 5 High Density", Area = 15 },
                new ProcessEquipmentType { Id = 6, Code = "EQ6", Name = "Type 6 Medium Equipment", Area = 45 },
                new ProcessEquipmentType { Id = 7, Code = "EQ7", Name = "Type 7 Advanced", Area = 90 },
                new ProcessEquipmentType { Id = 8, Code = "EQ8", Name = "Type 8 Lightweight", Area = 20 },
                new ProcessEquipmentType { Id = 9, Code = "EQ9", Name = "Type 9 Custom", Area = 100 },
                new ProcessEquipmentType { Id = 10, Code = "EQ10", Name = "Type 10 Extreme", Area = 200 }
            );
        }

    }
}
