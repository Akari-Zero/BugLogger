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
      modelBuilder.Entity<BugReport>().HasOne(b => b.DeveloperNotes).WithOne().HasForeignKey<DeveloperReport>(d => d.BugReportId);
    }
  }
}
