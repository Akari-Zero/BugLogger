using BugLogger.Domain.Models;

namespace BugLogger.Application.Repository
{
  /// <summary>
  /// Class <c>DeveloperReportsRepository</c> handles sending and receiving data to the database.
  /// </summary>
  public interface IDeveloperReportsRepository
  {
    /// <summary>
    /// Create a DeveloperReport to the database.
    /// </summary>
    /// <param name="entity">DeveloperReport to be added</param>
    /// <returns>Entity's database ID</returns>
    Task<int> CreateDeveloperReportAsync(DeveloperReport entity);

    /// <summary>
    /// Delete a DeveloperReport from the database.
    /// </summary>
    /// <param name="entity">The DeveloperReport to be deleted</param>
    Task DeleteDeveloperReportAsync(DeveloperReport entity);

    /// <summary>
    /// Retrieves a DeveloperReport from its id from the database.
    /// </summary>
    /// <param name="id">The report's database id</param>
    /// <returns>A DeveloperReport or null if not found</returns>
    Task<DeveloperReport?> GetByIdAsync(int id);
    
    /// <summary>
    /// Get a list of DeveloperReport based on Severity and Priority levels.
    /// </summary>
    /// <param name="severity">The severity of the bug</param>
    /// <param name="priority">The current priority of the bug</param>
    /// <returns>A filtered list of DeveloperReport</returns>
    Task<IEnumerable<DeveloperReport>> GetListByFilterAsync(Severity severity, Priority priority);
  }
}