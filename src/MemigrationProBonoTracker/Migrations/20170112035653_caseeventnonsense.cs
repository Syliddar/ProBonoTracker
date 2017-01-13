using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MemigrationProBonoTracker.Migrations
{
    public partial class caseeventnonsense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseEvents_Cases_CaseId",
                table: "CaseEvents");

            migrationBuilder.AlterColumn<int>(
                name: "CaseId",
                table: "CaseEvents",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseEvents_Cases_CaseId",
                table: "CaseEvents",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseEvents_Cases_CaseId",
                table: "CaseEvents");

            migrationBuilder.AlterColumn<int>(
                name: "CaseId",
                table: "CaseEvents",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CaseEvents_Cases_CaseId",
                table: "CaseEvents",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
