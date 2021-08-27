using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CommonObjectLibraryCore
{


    public class ProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:arda.database.windows.net,1433;Initial Catalog=radagast;Persist Security Info=False;User ID=boggsy;Password=Pa55w0rdPa55w0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseEntity>().HasKey(ce => new {ce.CaseId,ce.EntityId});

            AddSeedData(ref modelBuilder);


        }

        private void AddSeedData(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityType>().HasData(
                new EntityType {EntityTypeId = 1, EntityTypeName="Borrower"},
                new EntityType {EntityTypeId = 2, EntityTypeName="Solicitor"},
                new EntityType {EntityTypeId = 3, EntityTypeName="Client"}
                            );


        }

        public DbSet<Case> Cases {get; set;}
        public DbSet<Entity> Entities {get; set;}
        public DbSet<CaseEntity> CaseEntities {get; set;}
        public DbSet<EntityType> EntityTypes {get; set;}
    }
}