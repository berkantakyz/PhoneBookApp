using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhoneBook.Common.Models;

namespace PhoneBook.Data
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options) { }

        public DbSet<Person> Person { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<ReportDetail> ReportDetail { get; set; }
        public DbSet<ContactInfoType> ContactInfoType { get; set; }
        public DbSet<ReportStatus> ReportStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            var apiDirectory = Path.Combine(projectDirectory, "PhoneBook.Api");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(apiDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("cs");

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContactInfo>()
                .HasOne(c => c.InfoType)
                .WithMany(c => c.ContactInfos)
                .HasForeignKey(c => c.InfoTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<ContactInfo>()
                .HasOne(c => c.Person)
                .WithMany(p => p.ContactInfos)
                .HasForeignKey(c => c.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReportDetail>()
               .HasOne(rd => rd.Report) 
               .WithMany(r => r.ReportDetails)  
               .HasForeignKey(rd => rd.ReportId)  
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Report>()
                .HasOne(c => c.ReportStatus)
                .WithMany(c => c.Reports)
                .HasForeignKey(c => c.ReportStatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}