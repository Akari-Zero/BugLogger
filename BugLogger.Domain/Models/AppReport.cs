using System.ComponentModel.DataAnnotations;

namespace BugLogger.Domain.Models
{
  /// <summary>
  /// Class <c>AppReport</c> models the application with its multiple reports.
  /// </summary>
  public class AppReport
  {
    /// <summary>
    /// The database Id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of the application.
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The list of bugs that users submitted.
    /// </summary>
    public List<BugReport> Bugs { get; set; } = new List<BugReport>();


  }
}
