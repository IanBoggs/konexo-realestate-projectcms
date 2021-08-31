using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonObjectLibraryCore.Migrations
{
    public partial class fix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cases_ClientReference_ClientEntityId",
                table: "Cases");

            migrationBuilder.AlterColumn<string>(
                name: "ClientReference",
                table: "Cases",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ClientReference_ClientEntityId",
                table: "Cases",
                columns: new[] { "ClientReference", "ClientEntityId" },
                unique: true,
                filter: "[ClientEntityId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cases_ClientReference_ClientEntityId",
                table: "Cases");

            migrationBuilder.AlterColumn<string>(
                name: "ClientReference",
                table: "Cases",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ClientReference_ClientEntityId",
                table: "Cases",
                columns: new[] { "ClientReference", "ClientEntityId" },
                unique: true,
                filter: "[ClientReference] IS NOT NULL AND [ClientEntityId] IS NOT NULL");
        }
    }
}
