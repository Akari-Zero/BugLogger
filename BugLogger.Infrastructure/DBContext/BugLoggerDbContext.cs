using BugLogger.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BugLogger.Infrastructure.DBContext
{
  internal class BugLoggerDbContext(DbContextOptions<BugLoggerDbContext> options) : DbContext(options)
  {
    internal DbSet<User> Users { get; set; }
    internal DbSet<AppReport> Programs { get; set; }
    internal DbSet<BugReport> Bugs { get; set; }
    internal DbSet<DeveloperReport> DevNotes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<AppReport>().HasMany(a => a.Bugs).WithOne().HasForeignKey(b => b.AppReportId);
      modelBuilder.Entity<BugReport>().HasOne(b => b.DeveloperNotes);

      SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>().HasData(new User() { Id = 1, Name = "Jim"});

      modelBuilder.Entity<AppReport>().HasData(
        new AppReport()
        {
          Id = 1,
          Name = "BugLogger",
        }  
        
        );

      modelBuilder.Entity<BugReport>().HasData(
        new BugReport()
        {
          Id = 1,
          Title = "Initial Bug",
          ReproductionSteps = "No Bugs",
          ExpectedResult = "No Bugs",
          ActualResult = "Still in developement",
          Description = "Application is in development",
          Author = "Jim",
          TimeStamp = new DateTime(),
          IsResolved = false,
          AppReportId = 1
        }
      );

      modelBuilder.Entity<DeveloperReport>().HasData(
        new DeveloperReport()
        {
          Id = 1,
          SeverityLevel = Severity.Trival,
          PriorityLevel = Priority.None,
          Description = "In development",
          BugReportId = 1
        }
      );
    }
  }
}
