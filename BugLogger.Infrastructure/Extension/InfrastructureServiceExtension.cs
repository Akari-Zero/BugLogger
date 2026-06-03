using BugLogger.Application.Repository;
using BugLogger.Infrastructure.DBContext;
using BugLogger.Infrastructure.Repositories.Reports;
using BugLogger.Infrastructure.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BugLogger.Infrastructure.Extension
{
  public static class InfrastructureServiceExtension
  {
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
      var connectionString = configuration.GetConnectionString("BugLoggerDbContextConnection");
      services.AddDbContext<BugLoggerDbContext>(options => options.UseSqlServer(connectionString));

      services.AddScoped<IDeveloperReportsRepository, DeveloperReportsRepository>();
      services.AddScoped<IUsersRepository, UsersRepository>();
    }
  }
}
