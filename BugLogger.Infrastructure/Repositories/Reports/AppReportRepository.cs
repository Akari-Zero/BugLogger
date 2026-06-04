using BugLogger.Domain.Models;
using BugLogger.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace BugLogger.Infrastructure.Repositories.Reports
{
  /// <summary>
  /// Class <c>AppReportsRepository</c> handles sending and receiving data to the database.
  /// </summary>
  /// <param name="context"></param>
  internal class AppReportRepository(BugLoggerDbContext context)
  {
    /// <summary>
    /// Retrieves a AppReport from its id from the database.
    /// </summary>
    /// <param name="id">The report's database id</param>
    /// <returns>A AppReport or null if not found</returns>
    public async Task<AppReport?> GetByIdAsync(int id)
    {
      var report = await context.Programs.FirstOrDefaultAsync(p => p.Id == id);
      return report;
    }

    /// <summary>
    /// Retrives a list of AppReports from its database by the user id.
    /// </summary>
    /// <param name="id">The Id of the user</param>
    /// <returns>A list of AppReports</returns>
    public async Task<IEnumerable<AppReport>> GetAppReportsByUserIdAsync(int id)
    {
      var reports = await context.Programs.Where(p => p.UserId == id).ToListAsync();
      return reports;
    }

    /// <summary>
    /// Updates the name of the application.
    /// </summary>
    /// <param name="id">Id of the application.</param>
    /// <param name="name">New Name of the Application</param>
    /// <returns>True if the update was successful, else false if the id was not found.</returns>
    public async Task<bool> UpdateName(int id, string name)
    {
      var report = await context.Programs.FirstOrDefaultAsync(p => p.Id == id);
      if (report == null) return false;

      report.Name = name;

      await context.SaveChangesAsync();
      return true;
    }
  }
}
