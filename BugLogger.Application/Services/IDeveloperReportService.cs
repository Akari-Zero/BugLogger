using BugLogger.Domain.Models;

namespace BugLogger.Application.Services
{
  /// <summary>
  /// Interface <c>DeveloperReportService</c> handles calls to the repository for the application layer.
  /// </summary>
  public interface IDeveloperReportService
  {
    /// <summary>
    /// Create a DeveloperReport to the repository.
    /// </summary>
    /// <param name="entity">DeveloperReport to be added</param>
    /// <returns>Entity's ID</returns>
    Task<int> CreateDeveloperReportAsync(DeveloperReport entity);

    /// <summary>
    /// Delete a DeveloperReport from the repository.
    /// </summary>
    /// <param name="entity">The DeveloperReport to be deleted</param>
    Task DeleteDeveloperReportById(DeveloperReport entity);

    /// <summary>
    /// Retrieves a DeveloperReport from its id.
    /// </summary>
    /// <param name="id">The report's id</param>
    /// <returns>A DeveloperReport or null if not found</returns>
    Task<DeveloperReport?> GetById(int id);

    /// <summary>
    /// Get a list of DeveloperReport based on their associated BugReport Id.
    /// </summary>
    /// <param name="id">The Id of a BugReport</param>
    /// <returns>A list of DeveloperReport</returns>
    Task<IEnumerable<DeveloperReport>> GetListByBugReportId(int id);

    /// <summary>
    /// Get a list of DeveloperReport based on Severity and Priority levels.
    /// </summary>
    /// <param name="severity">The severity of the bug</param>
    /// <param name="priority">The current priority of the bug</param>
    /// <returns>A filtered list of DeveloperReport</returns>
    Task<IEnumerable<DeveloperReport>> GetListByFilter(Severity severity, Priority priority);
  }
}