using System.ComponentModel.DataAnnotations;

namespace BugLogger.Domain.Models
{
  /// <summary>
  /// Class <c>BugReport</c> models a bug report submitted to the application.
  /// </summary>
  public class BugReport
  {
    /// <summary>
    /// The database Id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The AppReport's bug id.
    /// </summary>
    [Required]
    public string BugId { get; set; } = string.Empty;

    /// <summary>
    /// Required title of the bug report.
    /// </summary>
    [Required]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Description of steps to reproduce the bug.
    /// </summary>
    [Required]
    public string ReproductionSteps = string.Empty;

    /// <summary>
    /// What the report expects the result to be.
    /// </summary>
    [Required]
    public string ExpectedResult = string.Empty;

    /// <summary>
    /// What the result of the bug occurred.
    /// </summary>
    [Required]
    public string ActualResult = string.Empty;

    /// <summary>
    /// General description of the bug.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Optional author of the bug report.
    /// </summary>
    public string Author { get; set; } = string.Empty;

    /// <summary>
    /// Stored date and time of when the report was submitted.
    /// </summary>
    [Required]
    public DateTime TimeStamp { get; set; }

    /// <summary>
    /// Optional image url linking the submission of the bug.
    /// </summary>
    public string ImageURL { get; set; } = string.Empty;

    /// <summary>
    /// The issue is resolved.
    /// </summary>
    public bool IsResolved { get; set; }

    /// <summary>
    /// The developer notes involving the issue.
    /// </summary>
    public DeveloperReport DeveloperNotes { get; set; } = new();

    /// <summary>
    /// The Foreign Key to match with the AppReport.
    /// </summary>
    public int AppReportId { get; set; }
  }
}
