using BugLogger.Application.Repository;
using BugLogger.Domain.Models;

namespace BugLogger.Application.Services
{
  /// <summary>
  /// Class <c>DeveloperReportService</c> handles calls to the repository for the application layer.
  /// </summary>
  /// <param name="repository"></param>
  internal class DeveloperReportService(IDeveloperReportsRepository repository) : IDeveloperReportService
  {
    /// <summary>
    /// Retrieves a DeveloperReport from its id.
    /// </summary>
    /// <param name="id">The report's id</param>
    /// <returns>A DeveloperReport or null if not found</returns>
    public async Task<DeveloperReport?> GetById(int id)
    {
      var report = await repository.GetByIdAsync(id);
      return report;
    }

    /// <summary>
    /// Get a list of DeveloperReport based on Severity and Priority levels.
    /// </summary>
    /// <param name="severity">The severity of the bug</param>
    /// <param name="priority">The current priority of the bug</param>
    /// <returns>A filtered list of DeveloperReport</returns>
    public async Task<IEnumerable<DeveloperReport>> GetListByFilter(Severity severity, Priority priority)
    {
      var reports = await repository.GetListByFilterAsync(severity, priority);
      return reports;
    }

    /// <summary>
    /// Delete a DeveloperReport from the repository.
    /// </summary>
    /// <param name="entity">The DeveloperReport to be deleted</param>
    public async Task DeleteDeveloperReport(DeveloperReport entity)
    {
      await repository.DeleteDeveloperReportAsync(entity);
    }

    /// <summary>
    /// Create a DeveloperReport to the repository.
    /// </summary>
    /// <param name="entity">DeveloperReport to be added</param>
    /// <returns>Entity's ID</returns>
    public async Task<int> CreateDeveloperReport(DeveloperReport entity)
    {
      var id = await repository.CreateDeveloperReportAsync(entity);
      return id;
    }
  }
}
