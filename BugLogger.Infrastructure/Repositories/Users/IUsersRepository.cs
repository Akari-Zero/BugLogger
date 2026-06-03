using BugLogger.Domain.Models;

namespace BugLogger.Infrastructure.Repositories.Users
{
  internal interface IUsersRepository
  {
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetById(int id);
    Task<User?> GetByName(string name);
  }
}