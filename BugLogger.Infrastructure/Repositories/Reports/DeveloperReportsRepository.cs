using BugLogger.Domain.Models;
using BugLogger.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace BugLogger.Infrastructure.Repositories.Reports
{
  internal class DeveloperReportsRepository(BugLoggerDbContext context)
  {
    public async Task<DeveloperReport?> GetByIdAsync(int id)
    {
      var report = await context.DevNotes.FirstOrDefaultAsync(d => d.Id == id);
      return report;
    }

    public async Task<IEnumerable<DeveloperReport>> GetListByBugReportId(int id)
    {
      var reports = await context.DevNotes.Where(d => d.BugReportId == id).ToListAsync();
      return reports;
    }

    public async Task<IEnumerable<DeveloperReport>> GetListByFilter(Severity severity, Priority priority)
    {
      var reports = await context.DevNotes.Where(d => d.SeverityLevel == severity && d.PriorityLevel == priority).ToListAsync();

      return reports;
    }
  }
}
