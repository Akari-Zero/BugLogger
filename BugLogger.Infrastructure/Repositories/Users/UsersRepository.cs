using BugLogger.Application.Repository;
using BugLogger.Domain.Models;
using BugLogger.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace BugLogger.Infrastructure.Repositories.Users
{
  /// <summary>
  /// Class <c>UsersRepository</c> handles sending and receiving data to the database.
  /// </summary>
  /// <param name="context">The DbContext of BugLogger</param>
  internal class UsersRepository(BugLoggerDbContext context) : IUsersRepository
  {
    /// <summary>
    /// Return a list of all Users.
    /// </summary>
    /// <returns>A list of User</returns>
    public async Task<IEnumerable<User>> GetAllAsync()
    {
      var users = await context.Users.ToListAsync();
      return users;
    }

    /// <summary>
    /// Get a User by their database Id.
    /// </summary>
    /// <param name="id">The database Id of the user.</param>
    /// <returns>The User or null if not found.</returns>
    public async Task<User?> GetById(int id)
    {
      var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
      return user;
    }

    /// <summary>
    /// Get a User by their name.
    /// </summary>
    /// <param name="name">Name of the user.</param>
    /// <returns>The User or null if not found.</returns>
    public async Task<User?> GetByName(string name)
    {
      var user = await context.Users.FirstOrDefaultAsync(u => u.Name == name);
      return user;
    }

    /// <summary>
    /// Create a User for the database.
    /// </summary>
    /// <param name="entity">The User data to be created.</param>
    /// <returns>The database id assigned to the entity.</returns>
    public async Task<int> CreateUser(User entity)
    {
      await context.Users.AddAsync(entity);
      await context.SaveChangesAsync();
      return entity.Id;
    }

    /// <summary>
    /// Delete a User from the database.
    /// </summary>
    /// <param name="entity">The entity to be deleted.</param>
    public async Task DeleteUser(User entity)
    {
      context.Remove(entity);
      await context.SaveChangesAsync();
    }
  }
}
