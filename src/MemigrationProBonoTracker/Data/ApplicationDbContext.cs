using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MemigrationProBonoTracker.Models;

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
        public DbSet<CaseLogEntry> LogEntries { get; set; }
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
            builder.Entity<Case>().HasOne(c => c.VolunteerAttorney);
            builder.Entity<Case>().HasMany(c => c.CaseEvents);
            //builder.Entity<Case>().HasMany(c => c.AssociatedPeopleList);

            builder.Entity<CaseEvent>().HasOne(e => e.ParentCase);

            builder.Entity<Attorney>().HasOne(a => a.Address);
            builder.Entity<Attorney>().HasOne(a => a.Phone);
            builder.Entity<Attorney>().HasOne(a => a.Email);

            builder.Entity<Person>().HasOne(p => p.Address);
            builder.Entity<Person>().HasOne(p => p.Phone);

            builder.Entity<CaseLogEntry>().HasOne(l => l.Case);

        }
    }
}
