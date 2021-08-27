using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonObjectLibraryCore.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaseEntityProperties",
                columns: table => new
                {
                    CaseEntityPropertiesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseEntityProperties", x => x.CaseEntityPropertiesId);
                });

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
                name: "Entities",
                columns: table => new
                {
                    EntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.EntityId);
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
                name: "CaseEntities",
                columns: table => new
                {
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false),
                    CaseEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityRoleId = table.Column<int>(type: "int", nullable: false),
                    CaseEntityPropertiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseEntities", x => new { x.CaseId, x.EntityId });
                    table.ForeignKey(
                        name: "FK_CaseEntities_CaseEntityProperties_CaseEntityPropertiesId",
                        column: x => x.CaseEntityPropertiesId,
                        principalTable: "CaseEntityProperties",
                        principalColumn: "CaseEntityPropertiesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseEntities_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "CaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseEntities_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseEntities_EntityRoles_EntityRoleId",
                        column: x => x.EntityRoleId,
                        principalTable: "EntityRoles",
                        principalColumn: "EntityRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EntityRoles",
                columns: new[] { "EntityRoleId", "EntityRoleName" },
                values: new object[] { 1, "Borrower" });

            migrationBuilder.InsertData(
                table: "EntityRoles",
                columns: new[] { "EntityRoleId", "EntityRoleName" },
                values: new object[] { 2, "Solicitor" });

            migrationBuilder.InsertData(
                table: "EntityRoles",
                columns: new[] { "EntityRoleId", "EntityRoleName" },
                values: new object[] { 3, "Client" });

            migrationBuilder.CreateIndex(
                name: "IX_CaseEntities_CaseEntityPropertiesId",
                table: "CaseEntities",
                column: "CaseEntityPropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEntities_EntityId",
                table: "CaseEntities",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEntities_EntityRoleId",
                table: "CaseEntities",
                column: "EntityRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CaseReference",
                table: "Cases",
                column: "CaseReference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntityRoles_EntityRoleName",
                table: "EntityRoles",
                column: "EntityRoleName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseEntities");

            migrationBuilder.DropTable(
                name: "CaseEntityProperties");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropTable(
                name: "EntityRoles");
        }
    }
}
