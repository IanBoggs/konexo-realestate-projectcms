﻿// <auto-generated />
using CommonObjectLibraryCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CommonObjectLibraryCore.Migrations
{
    [DbContext(typeof(ProjectContext))]
    partial class ProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CommonObjectLibraryCore.Case", b =>
                {
                    b.Property<int>("CaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CaseReference")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CaseId");

                    b.HasIndex("CaseReference")
                        .IsUnique();

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("CommonObjectLibraryCore.CaseEntity", b =>
                {
                    b.Property<int>("CaseId")
                        .HasColumnType("int");

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<int>("CaseEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CaseEntityPropertiesId")
                        .HasColumnType("int");

                    b.Property<int>("EntityRoleId")
                        .HasColumnType("int");

                    b.HasKey("CaseId", "EntityId");

                    b.HasIndex("CaseEntityPropertiesId");

                    b.HasIndex("EntityId");

                    b.HasIndex("EntityRoleId");

                    b.ToTable("CaseEntities");
                });

            modelBuilder.Entity("CommonObjectLibraryCore.CaseEntityProperties", b =>
                {
                    b.Property<int>("CaseEntityPropertiesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CaseEntityPropertiesId");

                    b.ToTable("CaseEntityProperties");
                });

            modelBuilder.Entity("CommonObjectLibraryCore.Entity", b =>
                {
                    b.Property<int>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityId");

                    b.ToTable("Entities");
                });

            modelBuilder.Entity("CommonObjectLibraryCore.EntityRole", b =>
                {
                    b.Property<int>("EntityRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EntityRoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EntityRoleId");

                    b.HasIndex("EntityRoleName")
                        .IsUnique();

                    b.ToTable("EntityRoles");

                    b.HasData(
                        new
                        {
                            EntityRoleId = 1,
                            EntityRoleName = "Borrower"
                        },
                        new
                        {
                            EntityRoleId = 2,
                            EntityRoleName = "Solicitor"
                        },
                        new
                        {
                            EntityRoleId = 3,
                            EntityRoleName = "Client"
                        });
                });

            modelBuilder.Entity("CommonObjectLibraryCore.CaseEntity", b =>
                {
                    b.HasOne("CommonObjectLibraryCore.CaseEntityProperties", "CaseEntityProperties")
                        .WithMany()
                        .HasForeignKey("CaseEntityPropertiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommonObjectLibraryCore.Case", "Case")
                        .WithMany("CaseEntities")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommonObjectLibraryCore.Entity", "Entity")
                        .WithMany("CaseEntities")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommonObjectLibraryCore.EntityRole", "EntityRole")
                        .WithMany()
                        .HasForeignKey("EntityRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Case");

                    b.Navigation("CaseEntityProperties");

                    b.Navigation("Entity");

                    b.Navigation("EntityRole");
                });

            modelBuilder.Entity("CommonObjectLibraryCore.Case", b =>
                {
                    b.Navigation("CaseEntities");
                });

            modelBuilder.Entity("CommonObjectLibraryCore.Entity", b =>
                {
                    b.Navigation("CaseEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
