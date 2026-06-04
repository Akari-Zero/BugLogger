using BugLogger.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BugLogger.Application.Extension
{
  public static class ApplicationServiceExtension
  {
    public static void AddApplication(this IServiceCollection services)
    {
      services.AddScoped<IDeveloperReportService, DeveloperReportService>();
    }
  }
}
