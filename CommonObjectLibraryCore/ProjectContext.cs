using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using System.Linq;

namespace CommonObjectLibraryCore
{


    public class ProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=tcp:arda.database.windows.net,1433;Initial Catalog=radagast;Persist Security Info=False;User ID=boggsy;Password=Pa55w0rdPa55w0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseEntity>().HasKey(ce => new { ce.CaseId, ce.EntityId });


            AddSeedData(ref modelBuilder);


        }

        private void AddSeedData(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityRole>().HasData(
                new EntityRole { EntityRoleId = 1, EntityRoleName = "Borrower" },
                new EntityRole { EntityRoleId = 2, EntityRoleName = "Solicitor" }
                            );
            modelBuilder.Entity<DataPointType>().HasData(
                new DataPointType { DataPointTypeId = 1, DataPointName = "Reference" }
            );

            modelBuilder.Entity<CaseStatus>().HasData(
                new CaseStatus { CaseStatusId = 1, CaseStatusName = "In Progress" },
                new CaseStatus { CaseStatusId = 2, CaseStatusName = "Aborted" },
                new CaseStatus { CaseStatusId = 3, CaseStatusName = "Completed" },
                new CaseStatus { CaseStatusId = 4, CaseStatusName = "PreCompletion" },
                new CaseStatus { CaseStatusId = 5, CaseStatusName = "PostCompletion" }
            );

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity { UserEntityId = 1, FullName = "Ian Boggs" },
                new UserEntity { UserEntityId = 2, FullName = "Sarah Jenkins" }
            );

        }

        public DbSet<Case> Cases { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<CaseEntity> CaseEntities { get; set; }
        public DbSet<EntityRole> EntityRoles { get; set; }

        public DbSet<PostalAddress> PostalAddresses { get; set; }
        public DbSet<CaseEntityDataPoint> CaseEntityDataPoints { get; set; }
        public DbSet<DataPointType> DataPointTypes { get; set; }
        public DbSet<IndividualEntity> People { get; set; }
        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CaseStatus> CaseStatusList { get; set; }

    }
}