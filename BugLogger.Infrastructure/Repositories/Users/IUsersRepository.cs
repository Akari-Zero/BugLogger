using BugLogger.Domain.Models;

namespace BugLogger.Infrastructure.Repositories.Users
{
  /// <summary>
  /// Class <c>UsersRepository</c> handles sending and receiving data to the database.
  /// </summary>
  public interface IUsersRepository
  {
    /// <summary>
    /// Return a list of all Users.
    /// </summary>
    /// <returns>A list of User</returns>
    Task<int> CreateUser(User entity);

    /// <summary>
    /// Get a User by their database Id.
    /// </summary>
    /// <param name="id">The database Id of the user.</param>
    /// <returns>The User or null if not found.</returns>
    Task DeleteUser(User entity);

    /// <summary>
    /// Get a User by their name.
    /// </summary>
    /// <param name="name">Name of the user.</param>
    /// <returns>The User or null if not found.</returns>
    Task<IEnumerable<User>> GetAllAsync();

    /// <summary>
    /// Create a User for the database.
    /// </summary>
    /// <param name="entity">The User data to be created.</param>
    /// <returns>The database id assigned to the entity.</returns>
    Task<User?> GetById(int id);

    /// <summary>
    /// Delete a User from the database.
    /// </summary>
    /// <param name="entity">The entity to be deleted.</param>
    Task<User?> GetByName(string name);
  }
}