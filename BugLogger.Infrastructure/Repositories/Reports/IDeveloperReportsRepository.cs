using BugLogger.Domain.Models;

namespace BugLogger.Infrastructure.Repositories.Reports
{
  /// <summary>
  /// Class <c>DeveloperReportsRepository</c> handles sending and receiving data to the database.
  /// </summary>
  public interface IDeveloperReportsRepository
  {
    /// <summary>
    /// Retrieves a DeveloperReport from its id from the database.
    /// </summary>
    /// <param name="id">The report's database id</param>
    /// <returns>A DeveloperReport or null if not found</returns>
    Task<int> CreateDeveloperReport(DeveloperReport entity);

    /// <summary>
    /// Get a list of DeveloperReport based on their associated BugReport Id.
    /// </summary>
    /// <param name="id">The Id of a BugReport</param>
    /// <returns>A list of DeveloperReport</returns>
    Task DeleteDeveloperReportById(DeveloperReport entity);

    /// <summary>
    /// Get a list of DeveloperReport based on Severity and Priority levels.
    /// </summary>
    /// <param name="severity">The severity of the bug</param>
    /// <param name="priority">The current priority of the bug</param>
    /// <returns>A filtered list of DeveloperReport</returns>
    Task<DeveloperReport?> GetByIdAsync(int id);

    /// <summary>
    /// Delete a DeveloperReport from the database.
    /// </summary>
    /// <param name="entity">The DeveloperReport to be deleted</param>
    Task<IEnumerable<DeveloperReport>> GetListByBugReportId(int id);

    /// <summary>
    /// Create a DeveloperReport to the database.
    /// </summary>
    /// <param name="entity">DeveloperReport to be added</param>
    /// <returns>Entity's database ID</returns>
    Task<IEnumerable<DeveloperReport>> GetListByFilter(Severity severity, Priority priority);
  }
}