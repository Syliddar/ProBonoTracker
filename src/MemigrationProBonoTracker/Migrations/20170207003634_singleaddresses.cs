using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MemigrationProBonoTracker.Migrations
{
    public partial class singleaddresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttorneyAddresses_Attorneys_AttorneyId",
                table: "AttorneyAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_AttorneyPhoneNumbers_Attorneys_AttorneyId",
                table: "AttorneyPhoneNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailAddresses_Attorneys_AttorneyId",
                table: "EmailAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonAddresses_People_PersonId",
                table: "PersonAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonPhoneNumbers_People_PersonId",
                table: "PersonPhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_PersonPhoneNumbers_PersonId",
                table: "PersonPhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_PersonAddresses_PersonId",
                table: "PersonAddresses");

            migrationBuilder.DropIndex(
                name: "IX_EmailAddresses_AttorneyId",
                table: "EmailAddresses");

            migrationBuilder.DropIndex(
                name: "IX_AttorneyPhoneNumbers_AttorneyId",
                table: "AttorneyPhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_AttorneyAddresses_AttorneyId",
                table: "AttorneyAddresses");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "PersonPhoneNumbers");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "PersonAddresses");

            migrationBuilder.DropColumn(
                name: "AttorneyId",
                table: "EmailAddresses");

            migrationBuilder.DropColumn(
                name: "AttorneyId",
                table: "AttorneyPhoneNumbers");

            migrationBuilder.DropColumn(
                name: "AttorneyId",
                table: "AttorneyAddresses");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneId",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Attorneys",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmailId",
                table: "Attorneys",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneId",
                table: "Attorneys",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_AddressId",
                table: "People",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_People_PhoneId",
                table: "People",
                column: "PhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Attorneys_AddressId",
                table: "Attorneys",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Attorneys_EmailId",
                table: "Attorneys",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_Attorneys_PhoneId",
                table: "Attorneys",
                column: "PhoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attorneys_AttorneyAddresses_AddressId",
                table: "Attorneys",
                column: "AddressId",
                principalTable: "AttorneyAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attorneys_EmailAddresses_EmailId",
                table: "Attorneys",
                column: "EmailId",
                principalTable: "EmailAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attorneys_AttorneyPhoneNumbers_PhoneId",
                table: "Attorneys",
                column: "PhoneId",
                principalTable: "AttorneyPhoneNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_PersonAddresses_AddressId",
                table: "People",
                column: "AddressId",
                principalTable: "PersonAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_PersonPhoneNumbers_PhoneId",
                table: "People",
                column: "PhoneId",
                principalTable: "PersonPhoneNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attorneys_AttorneyAddresses_AddressId",
                table: "Attorneys");

            migrationBuilder.DropForeignKey(
                name: "FK_Attorneys_EmailAddresses_EmailId",
                table: "Attorneys");

            migrationBuilder.DropForeignKey(
                name: "FK_Attorneys_AttorneyPhoneNumbers_PhoneId",
                table: "Attorneys");

            migrationBuilder.DropForeignKey(
                name: "FK_People_PersonAddresses_AddressId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_PersonPhoneNumbers_PhoneId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_AddressId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_PhoneId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_Attorneys_AddressId",
                table: "Attorneys");

            migrationBuilder.DropIndex(
                name: "IX_Attorneys_EmailId",
                table: "Attorneys");

            migrationBuilder.DropIndex(
                name: "IX_Attorneys_PhoneId",
                table: "Attorneys");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PhoneId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Attorneys");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "Attorneys");

            migrationBuilder.DropColumn(
                name: "PhoneId",
                table: "Attorneys");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "PersonPhoneNumbers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "PersonAddresses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AttorneyId",
                table: "EmailAddresses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AttorneyId",
                table: "AttorneyPhoneNumbers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AttorneyId",
                table: "AttorneyAddresses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonPhoneNumbers_PersonId",
                table: "PersonPhoneNumbers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddresses_PersonId",
                table: "PersonAddresses",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddresses_AttorneyId",
                table: "EmailAddresses",
                column: "AttorneyId");

            migrationBuilder.CreateIndex(
                name: "IX_AttorneyPhoneNumbers_AttorneyId",
                table: "AttorneyPhoneNumbers",
                column: "AttorneyId");

            migrationBuilder.CreateIndex(
                name: "IX_AttorneyAddresses_AttorneyId",
                table: "AttorneyAddresses",
                column: "AttorneyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttorneyAddresses_Attorneys_AttorneyId",
                table: "AttorneyAddresses",
                column: "AttorneyId",
                principalTable: "Attorneys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AttorneyPhoneNumbers_Attorneys_AttorneyId",
                table: "AttorneyPhoneNumbers",
                column: "AttorneyId",
                principalTable: "Attorneys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailAddresses_Attorneys_AttorneyId",
                table: "EmailAddresses",
                column: "AttorneyId",
                principalTable: "Attorneys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonAddresses_People_PersonId",
                table: "PersonAddresses",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonPhoneNumbers_People_PersonId",
                table: "PersonPhoneNumbers",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
