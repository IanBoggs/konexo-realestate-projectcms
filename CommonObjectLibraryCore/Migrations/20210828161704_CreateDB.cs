using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonObjectLibraryCore.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    CaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseReference = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.CaseId);
                });

            migrationBuilder.CreateTable(
                name: "DataPointTypes",
                columns: table => new
                {
                    DataPointTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPointName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPointTypes", x => x.DataPointTypeId);
                });

            migrationBuilder.CreateTable(
                name: "EntityRoles",
                columns: table => new
                {
                    EntityRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityRoleName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityRoles", x => x.EntityRoleId);
                });

            migrationBuilder.CreateTable(
                name: "PostalAddresses",
                columns: table => new
                {
                    PostalAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalAddresses", x => x.PostalAddressId);
                });

            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrincipalAddressPostalAddressId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Entities_PostalAddresses_PrincipalAddressPostalAddressId",
                        column: x => x.PrincipalAddressPostalAddressId,
                        principalTable: "PostalAddresses",
                        principalColumn: "PostalAddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseEntities",
                columns: table => new
                {
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaseEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityRoleId = table.Column<int>(type: "int", nullable: false),
                    CompanyEntityEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IndividualEntityEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseEntities", x => new { x.CaseId, x.EntityId });
                    table.ForeignKey(
                        name: "FK_CaseEntities_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "CaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseEntities_Entities_CompanyEntityEntityId",
                        column: x => x.CompanyEntityEntityId,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseEntities_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseEntities_Entities_IndividualEntityEntityId",
                        column: x => x.IndividualEntityEntityId,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseEntities_EntityRoles_EntityRoleId",
                        column: x => x.EntityRoleId,
                        principalTable: "EntityRoles",
                        principalColumn: "EntityRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseEntityDataPoints",
                columns: table => new
                {
                    CaseEntityDataPointId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPointTypeId = table.Column<int>(type: "int", nullable: false),
                    DataPointValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseEntityCaseId = table.Column<int>(type: "int", nullable: true),
                    CaseEntityEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseEntityDataPoints", x => x.CaseEntityDataPointId);
                    table.ForeignKey(
                        name: "FK_CaseEntityDataPoints_CaseEntities_CaseEntityCaseId_CaseEntityEntityId",
                        columns: x => new { x.CaseEntityCaseId, x.CaseEntityEntityId },
                        principalTable: "CaseEntities",
                        principalColumns: new[] { "CaseId", "EntityId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseEntityDataPoints_DataPointTypes_DataPointTypeId",
                        column: x => x.DataPointTypeId,
                        principalTable: "DataPointTypes",
                        principalColumn: "DataPointTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DataPointTypes",
                columns: new[] { "DataPointTypeId", "DataPointName" },
                values: new object[] { 1, "Reference" });

            migrationBuilder.InsertData(
                table: "EntityRoles",
                columns: new[] { "EntityRoleId", "EntityRoleName" },
                values: new object[,]
                {
                    { 1, "Borrower" },
                    { 2, "Solicitor" },
                    { 3, "Client" },
                    { 4, "Case Handler" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseEntities_CompanyEntityEntityId",
                table: "CaseEntities",
                column: "CompanyEntityEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEntities_EntityId",
                table: "CaseEntities",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEntities_EntityRoleId",
                table: "CaseEntities",
                column: "EntityRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEntities_IndividualEntityEntityId",
                table: "CaseEntities",
                column: "IndividualEntityEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEntityDataPoints_CaseEntityCaseId_CaseEntityEntityId",
                table: "CaseEntityDataPoints",
                columns: new[] { "CaseEntityCaseId", "CaseEntityEntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_CaseEntityDataPoints_DataPointTypeId",
                table: "CaseEntityDataPoints",
                column: "DataPointTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CaseReference",
                table: "Cases",
                column: "CaseReference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entities_PrincipalAddressPostalAddressId",
                table: "Entities",
                column: "PrincipalAddressPostalAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityRoles_EntityRoleName",
                table: "EntityRoles",
                column: "EntityRoleName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseEntityDataPoints");

            migrationBuilder.DropTable(
                name: "CaseEntities");

            migrationBuilder.DropTable(
                name: "DataPointTypes");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropTable(
                name: "EntityRoles");

            migrationBuilder.DropTable(
                name: "PostalAddresses");
        }
    }
}
