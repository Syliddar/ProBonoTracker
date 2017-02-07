using Microsoft.EntityFrameworkCore.Migrations;

namespace MemigrationProBonoTracker.Migrations
{
    public partial class PhoneType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimaryContactNumber",
                table: "PersonPhoneNumbers");

            migrationBuilder.DropColumn(
                name: "PrimaryContactNumber",
                table: "AttorneyPhoneNumbers");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "PersonPhoneNumbers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "AttorneyPhoneNumbers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "PersonPhoneNumbers");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "AttorneyPhoneNumbers");

            migrationBuilder.AddColumn<bool>(
                name: "PrimaryContactNumber",
                table: "PersonPhoneNumbers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PrimaryContactNumber",
                table: "AttorneyPhoneNumbers",
                nullable: false,
                defaultValue: false);
        }
    }
}
