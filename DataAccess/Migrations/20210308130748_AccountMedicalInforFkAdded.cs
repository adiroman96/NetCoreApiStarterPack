using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AccountMedicalInforFkAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "Accounts",
                newName: "Username");

            migrationBuilder.AddColumn<long>(
                name: "AccountID",
                table: "MedicalInformations",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInformations_AccountID",
                table: "MedicalInformations",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalInformations_Accounts_AccountID",
                table: "MedicalInformations",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalInformations_Accounts_AccountID",
                table: "MedicalInformations");

            migrationBuilder.DropIndex(
                name: "IX_MedicalInformations_AccountID",
                table: "MedicalInformations");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "MedicalInformations");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Accounts",
                newName: "username");
        }
    }
}
