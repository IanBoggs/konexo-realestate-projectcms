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
            modelBuilder.Entity<EntityRole>().HasData(
                new EntityRole {EntityRoleId = 1, EntityRoleName="Borrower"},
                new EntityRole {EntityRoleId = 2, EntityRoleName="Solicitor"},
                new EntityRole {EntityRoleId = 3, EntityRoleName="Client"}
                            );


        }

        public DbSet<Case> Cases {get; set;}
        public DbSet<Entity> Entities {get; set;}
        public DbSet<CaseEntity> CaseEntities {get; set;}
        public DbSet<EntityRole> EntityRoles {get; set;}

        public DbSet<CaseEntityProperties> CaseEntityProperties {get; set;}
    }
}