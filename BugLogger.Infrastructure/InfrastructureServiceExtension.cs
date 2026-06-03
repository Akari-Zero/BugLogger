using BugLogger.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BugLogger.Infrastructure
{
  public static class InfrastructureServiceExtension
  {
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
      var connectionString = configuration.GetConnectionString("BugLoggerDbContextConnection");
      services.AddDbContext<BugLoggerDbContext>(options => options.UseSqlServer(connectionString));

    }
  }
}
