using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MemigrationProBonoTracker.Migrations
{
    public partial class caserefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Attorneys_VolunteerAttorneyId",
                table: "Cases");

            migrationBuilder.AlterColumn<int>(
                name: "VolunteerAttorneyId",
                table: "Cases",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AlterColumn<int>(
                name: "VolunteerAttorneyId",
                table: "Cases",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Attorneys_VolunteerAttorneyId",
                table: "Cases",
                column: "VolunteerAttorneyId",
                principalTable: "Attorneys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
