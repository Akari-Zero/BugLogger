using BugLogger.Domain.Models;
using BugLogger.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace BugLogger.Infrastructure.Repositories.Reports
{
  /// <summary>
  /// Class <c>DeveloperReportsRepository</c> handles sending and receiving data to the database.
  /// </summary>
  /// <param name="context">The DBContext of the BugLogger</param>
  internal class DeveloperReportsRepository(BugLoggerDbContext context)
  {
    /// <summary>
    /// Retrieves a DeveloperReport from its id from the database.
    /// </summary>
    /// <param name="id">The report's database id</param>
    /// <returns>A DeveloperReport or null if not found</returns>
    public async Task<DeveloperReport?> GetByIdAsync(int id)
    {
      var report = await context.DevNotes.FirstOrDefaultAsync(d => d.Id == id);
      return report;
    }

    /// <summary>
    /// Get a list of DeveloperReport based on their associated BugReport Id.
    /// </summary>
    /// <param name="id">The Id of a BugReport</param>
    /// <returns>A list of DeveloperReport</returns>
    public async Task<IEnumerable<DeveloperReport>> GetListByBugReportId(int id)
    {
      var reports = await context.DevNotes.Where(d => d.BugReportId == id).ToListAsync();
      return reports;
    }

    /// <summary>
    /// Get a list of DeveloperReport based on Severity and Priority levels.
    /// </summary>
    /// <param name="severity">The severity of the bug</param>
    /// <param name="priority">The current priority of the bug</param>
    /// <returns>A filtered list of DeveloperReport</returns>
    public async Task<IEnumerable<DeveloperReport>> GetListByFilter(Severity severity, Priority priority)
    {
      var reports = await context.DevNotes.Where(d => d.SeverityLevel == severity && d.PriorityLevel == priority).ToListAsync();

      return reports;
    }

    /// <summary>
    /// Delete a DeveloperReport from the database.
    /// </summary>
    /// <param name="entity">The DeveloperReport to be deleted</param>
    public async Task DeleteDeveloperReportById(DeveloperReport entity)
    {
      var report = context.Remove(entity);
      await context.SaveChangesAsync();
    }

    /// <summary>
    /// Create a DeveloperReport to the database.
    /// </summary>
    /// <param name="entity">DeveloperReport to be added</param>
    /// <returns>Entity's database ID</returns>
    public async Task<int> CreateDeveloperReport(DeveloperReport entity)
    {
      await context.DevNotes.AddAsync(entity);
      await context.SaveChangesAsync();
      return entity.Id;
    }


  }
}
