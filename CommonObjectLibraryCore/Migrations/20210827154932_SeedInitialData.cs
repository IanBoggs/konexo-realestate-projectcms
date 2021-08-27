using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonObjectLibraryCore.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EntityTypes",
                columns: new[] { "EntityTypeId", "EntityTypeName" },
                values: new object[] { 1, "Borrower" });

            migrationBuilder.InsertData(
                table: "EntityTypes",
                columns: new[] { "EntityTypeId", "EntityTypeName" },
                values: new object[] { 2, "Solicitor" });

            migrationBuilder.InsertData(
                table: "EntityTypes",
                columns: new[] { "EntityTypeId", "EntityTypeName" },
                values: new object[] { 3, "Client" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "EntityTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "EntityTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "EntityTypeId",
                keyValue: 3);
        }
    }
}
