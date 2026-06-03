using BugLogger.Domain.Models;
using BugLogger.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace BugLogger.Infrastructure.Repositories.Users
{
  internal class UsersRepository(BugLoggerDbContext context) : IUsersRepository
  {
    public async Task<IEnumerable<User>> GetAllAsync()
    {
      var users = await context.Users.ToListAsync();
      return users;
    }

    public async Task<User?> GetById(int id)
    {
      var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
      return user;
    }

    public async Task<User?> GetByName(string name)
    {
      var user = await context.Users.FirstOrDefaultAsync(u => u.Name == name);
      return user;
    }
  }
}
