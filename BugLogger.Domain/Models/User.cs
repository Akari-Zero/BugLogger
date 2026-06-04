using System.ComponentModel.DataAnnotations;

namespace BugLogger.Domain.Models
{
  /// <summary>
  /// Class <c>User</c> models the user information.
  /// </summary>
  public class User
  {
    /// <summary>
    /// The database Id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// User name.
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// List of applications the User owns.
    /// </summary>
    public List<AppReport> Applications { get; set; } = new();
  }
}
