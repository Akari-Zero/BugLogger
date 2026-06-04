using BugLogger.Application.Services;
using BugLogger.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugLogger.API.Controllers
{
  /// <summary>
  /// Class <c>DevNotesController</c> is a controller that handles API calls for DevNotes.
  /// </summary>
  /// <param name="devService"></param>
  [ApiController]
  [Route("api/devnotes")]
  public class DevNotesController(IDeveloperReportService devService) : ControllerBase
  {
    /// <summary>
    /// Creates a Dev Note.
    /// </summary>
    /// <param name="notes">Entity of the Dev Notes.</param>
    /// <returns>Request code.</returns>
    [HttpPost]
    public async Task<IActionResult> CreateDevNotes(DeveloperReport notes)
    {
      if (notes.Id > 0)
        return BadRequest();
      var id = await devService.CreateDeveloperReport(notes);
      return Ok(notes);
    }

    /// <summary>
    /// Deletes a Dev Note.
    /// </summary>
    /// <param name="notes">Entity of the Dev Notes.</param>
    /// <returns>Request Code.</returns>
    [HttpDelete]
    public async Task<IActionResult> DeleteDevNotes(DeveloperReport notes)
    { 
      var report = devService.GetById(notes.Id);
      if (report == null)
        return NotFound(notes);
      await devService.DeleteDeveloperReport(notes);
      return Ok(notes);
    }

    /// <summary>
    /// Get a dev note by Id.
    /// </summary>
    /// <param name="id">Id of the DevNote</param>
    /// <returns>Request Code</returns>
    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
      var report = await devService.GetById(id);
      if (report == null)
        return NotFound(id);
      return Ok(report);
    }
  }
}
