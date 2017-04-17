using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MemigrationProBonoTracker.Data;
using MemigrationProBonoTracker.Models;

namespace MemigrationProBonoTracker.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170417164341_FeesPaid")]
    partial class FeesPaid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MemigrationProBonoTracker.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MemigrationProBonoTracker.Models.Attorney", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressId");

                    b.Property<string>("BarNumber");

                    b.Property<double>("ClcContribution");

                    b.Property<bool>("DesiredVolunteer");

                    b.Property<int?>("EmailId");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<bool>("HasImmigrationExperience");

                    b.Property<bool>("HasJuvenileExperience");

                    b.Property<bool>("HasProbateExperience");

                    b.Property<bool>("InterestedVolunteer");

                    b.Property<bool>("IsAssigningAttorney");

                    b.Property<string>("LastName");

                    b.Property<double>("LatinoMemContribution");

                    b.Property<double>("MiaContribution");

                    b.Property<string>("Notes");

                    b.Property<string>("OrganizationName");

                    b.Property<int?>("PhoneId");

                    b.Property<DateTime>("RecruitmentDate");

                    b.Property<int>("RecruitmentMethod");

                    b.Property<bool>("SpeaksSpanish");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("EmailId");

                    b.HasIndex("PhoneId");

                    b.ToTable("Attorneys");
                });

            modelBuilder.Entity("MemigrationProBonoTracker.Models.AttorneyAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<int>("Country");

                    b.Property<bool>("PrimaryAddress");

                    b.Property<string>("State");

                    b.Property<string>("StreetAddress");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("AttorneyAddresses");
                });

            modelBuilder.Entity("MemigrationProBonoTracker.Models.AttorneyPhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Number");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("AttorneyPhoneNumbers");
                });

            modelBuilder.Entity("MemigrationProBonoTracker.Models.Case", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int>("AssigningAttorneyId");

                    b.Property<double>("AttorneyWorkedHours");

                    b.Property<string>("CaseNotes");

                    b.Property<DateTime>("DateCreated");

                    b.Property<float>("FeesPaid");

                    b.Property<int>("LeadClientId");

                    b.Property<int>("Type");

                    b.Property<int?>("VolunteerAttorneyId");

                    b.HasKey("Id");

                    b.HasIndex("AssigningAttorneyId");

                    b.HasIndex("LeadClientId");

                    b.HasIndex("VolunteerAttorneyId");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("MemigrationProBonoTracker.Models.CaseEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CaseId");

                    b.Property<string>("Event");

                    b.Property<DateTime>("EventDate");

                    b.HasKey("Id");

                    b.HasIndex("CaseId");

                    b.ToTable("CaseEvents");
                });

            modelBuilder.Entity("MemigrationProBonoTracker.Models.CaseLogEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CaseId");

                    b.Property<DateTime>("EntryDate");

                    b.Property<string>("EntryNotes");

                    b.HasKey("Id");

                    b.HasIndex("CaseId");

                    b.ToTable("LogEntries");
                });

            modelBuilder.Entity("MemigrationProBonoTracker.Models.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.HasKey("Id");

                    b.ToTable("EmailAddresses");
                });

            modelBuilder.Entity("MemigrationProBonoTracker.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressId");

                    b.Property<string>("AlienNumber");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<string>("LastName");

                    b.Property<int>("Nationality");

                    b.Property<string>("Notes");

                    b.Property<int?>("PhoneId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("PhoneId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("MemigrationProBonoTracker.Models.PersonAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<int>("Country");

                    b.Property<bool>("PrimaryAddress");

                    b.Property<string>("State");

                    b.Property<string>("StreetAddress");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("PersonAddresses");
                });

            modelBuilder.Entity("MemigrationProBonoTracker.Models.PersonPhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Number");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("PersonPhoneNumbers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MemigrationProBonoTracker.Models.Attorney", b =>
                {
                    b.HasOne("MemigrationProBonoTracker.Models.AttorneyAddress", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("MemigrationProBonoTracker.Models.Email", "Email")
                        .WithMany()
                        .HasForeignKey("EmailId");

                    b.HasOne("MemigrationProBonoTracker.Models.AttorneyPhoneNumber", "Phone")
                        .WithMany()
                        .HasForeignKey("PhoneId");
                });

            modelBuilder.Entity("MemigrationProBonoTracker.Models.Case", b =>
                {
                    b.HasOne("MemigrationProBonoTracker.Models.Attorney", "AssigningAttorney")
                        .WithMany()
                        .HasForeignKey("AssigningAttorneyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MemigrationProBonoTracker.Models.Person", "LeadClient")
                        .WithMany()
                        .HasForeignKey("LeadClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MemigrationProBonoTracker.Models.Attorney", "VolunteerAttorney")
                        .WithMany()
                        .HasForeignKey("VolunteerAttorneyId");
                });

            modelBuilder.Entity("MemigrationProBonoTracker.Models.CaseEvent", b =>
                {
                    b.HasOne("MemigrationProBonoTracker.Models.Case", "ParentCase")
                        .WithMany("CaseEvents")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MemigrationProBonoTracker.Models.CaseLogEntry", b =>
                {
                    b.HasOne("MemigrationProBonoTracker.Models.Case", "Case")
                        .WithMany()
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MemigrationProBonoTracker.Models.Person", b =>
                {
                    b.HasOne("MemigrationProBonoTracker.Models.PersonAddress", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("MemigrationProBonoTracker.Models.PersonPhoneNumber", "Phone")
                        .WithMany()
                        .HasForeignKey("PhoneId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MemigrationProBonoTracker.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MemigrationProBonoTracker.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MemigrationProBonoTracker.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
