namespace BugLogger.Domain.Models
{
  /// <summary>
  /// Class <c>DeveloperReport</c> models the response report of the developer to a BugReport.
  /// </summary>
  public class DeveloperReport
  {
    /// <summary>
    /// The database Id. 
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The issue is revolved.
    /// </summary>
    public bool IsResolved { get; set; } = false;

    /// <summary>
    /// The severity level of the bug.
    /// </summary>
    public Severity SeverityLevel { get; set; } = Severity.Unknown;

    /// <summary>
    /// The developer notes about the issue.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Priority Level of the bug.
    /// </summary>
    public Priority PriorityLevel { get; set; } = Priority.None;

    /// <summary>
    /// The Foreign key to the BugReport.
    /// </summary>
    public int BugReportId { get; set; }
  }
}
