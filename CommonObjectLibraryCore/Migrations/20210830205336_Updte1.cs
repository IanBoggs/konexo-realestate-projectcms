using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonObjectLibraryCore.Migrations
{
    public partial class Updte1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefaultBankDetailsBankDetailId",
                table: "Entities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BankDetailId",
                table: "CaseEntity_Rel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BankDetails",
                columns: table => new
                {
                    BankDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDetails", x => x.BankDetailId);
                    table.ForeignKey(
                        name: "FK_BankDetails_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entities_DefaultBankDetailsBankDetailId",
                table: "Entities",
                column: "DefaultBankDetailsBankDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEntity_Rel_BankDetailId",
                table: "CaseEntity_Rel",
                column: "BankDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_EntityId",
                table: "BankDetails",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseEntity_Rel_BankDetails_BankDetailId",
                table: "CaseEntity_Rel",
                column: "BankDetailId",
                principalTable: "BankDetails",
                principalColumn: "BankDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entities_BankDetails_DefaultBankDetailsBankDetailId",
                table: "Entities",
                column: "DefaultBankDetailsBankDetailId",
                principalTable: "BankDetails",
                principalColumn: "BankDetailId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseEntity_Rel_BankDetails_BankDetailId",
                table: "CaseEntity_Rel");

            migrationBuilder.DropForeignKey(
                name: "FK_Entities_BankDetails_DefaultBankDetailsBankDetailId",
                table: "Entities");

            migrationBuilder.DropTable(
                name: "BankDetails");

            migrationBuilder.DropIndex(
                name: "IX_Entities_DefaultBankDetailsBankDetailId",
                table: "Entities");

            migrationBuilder.DropIndex(
                name: "IX_CaseEntity_Rel_BankDetailId",
                table: "CaseEntity_Rel");

            migrationBuilder.DropColumn(
                name: "DefaultBankDetailsBankDetailId",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "BankDetailId",
                table: "CaseEntity_Rel");
        }
    }
}
