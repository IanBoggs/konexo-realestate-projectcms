using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonObjectLibraryCore.Migrations
{
    public partial class fix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Users_CaseHandlerUserEntityId",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_CaseHandlerUserEntityId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "CaseHandlerUserEntityId",
                table: "Cases");

            migrationBuilder.AddColumn<int>(
                name: "CaseHandlerId",
                table: "Cases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CaseHandlerId",
                table: "Cases",
                column: "CaseHandlerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Users_CaseHandlerId",
                table: "Cases",
                column: "CaseHandlerId",
                principalTable: "Users",
                principalColumn: "UserEntityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Users_CaseHandlerId",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_CaseHandlerId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "CaseHandlerId",
                table: "Cases");

            migrationBuilder.AddColumn<int>(
                name: "CaseHandlerUserEntityId",
                table: "Cases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CaseHandlerUserEntityId",
                table: "Cases",
                column: "CaseHandlerUserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Users_CaseHandlerUserEntityId",
                table: "Cases",
                column: "CaseHandlerUserEntityId",
                principalTable: "Users",
                principalColumn: "UserEntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
