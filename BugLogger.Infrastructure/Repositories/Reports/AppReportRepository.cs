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

    public async Task UpdateName(int id, string name)
    {
      var report = await context.Programs.FirstOrDefaultAsync(p => p.Id == id);
      if (report == null)
      {
      }
    }
  }
}
