using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MemigrationProBonoTracker.Models;
using Microsoft.AspNetCore.Builder;

namespace MemigrationProBonoTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<AttorneyAddress> AttorneyAddresses { get; set; }
        public DbSet<AttorneyPhoneNumber> AttorneyPhoneNumbers { get; set; }
        public DbSet<PersonAddress> PersonAddresses { get; set; }
        public DbSet<PersonPhoneNumber> PersonPhoneNumbers { get; set; }
        public DbSet<Email> EmailAddresses { get; set; }
        public DbSet<Attorney> Attorneys { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<CaseEvent> CaseEvents { get; set; }
        public DbSet<ContactLogEntry> LogEntries { get; set; }
        public DbSet<Person> People { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Case>().HasOne(c => c.LeadClient);
            builder.Entity<Case>().HasOne(c => c.AssigningAttorney);
            builder.Entity<Case>().HasOne(c => c.AttorneyWorker);
            builder.Entity<Case>().HasMany(c => c.CaseEventDates);
            builder.Entity<Case>().HasMany(c => c.AssociatedPeopleList);

            builder.Entity<CaseEvent>().HasOne(e => e.ParentCase);

            builder.Entity<Attorney>().HasMany(a => a.AddressList);
            builder.Entity<Attorney>().HasMany(a => a.PhoneList);
            builder.Entity<Attorney>().HasMany(a => a.EmailList);

            builder.Entity<Person>().HasMany(p => p.AddressList);
            builder.Entity<Person>().HasMany(p=> p.PhoneList);

            builder.Entity<ContactLogEntry>().HasOne(l => l.Case);

        }
    }
}
