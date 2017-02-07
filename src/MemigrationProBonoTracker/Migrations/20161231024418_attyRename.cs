using Microsoft.EntityFrameworkCore.Migrations;

namespace MemigrationProBonoTracker.Migrations
{
    public partial class attyRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Attorneys_AttorneyWorkerId",
                table: "Cases");

            migrationBuilder.RenameColumn(
                name: "AttorneyWorkerId",
                table: "Cases",
                newName: "VolunteerAttorneyId");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_AttorneyWorkerId",
                table: "Cases",
                newName: "IX_Cases_VolunteerAttorneyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Attorneys_VolunteerAttorneyId",
                table: "Cases",
                column: "VolunteerAttorneyId",
                principalTable: "Attorneys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Attorneys_VolunteerAttorneyId",
                table: "Cases");

            migrationBuilder.RenameColumn(
                name: "VolunteerAttorneyId",
                table: "Cases",
                newName: "AttorneyWorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_VolunteerAttorneyId",
                table: "Cases",
                newName: "IX_Cases_AttorneyWorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Attorneys_AttorneyWorkerId",
                table: "Cases",
                column: "AttorneyWorkerId",
                principalTable: "Attorneys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
