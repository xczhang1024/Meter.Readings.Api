using System.ComponentModel.DataAnnotations;
using Meter.Readings.Api.DataAccess.ValidationAttributes;

namespace Meter.Readings.Api.DataAccess;

/// <summary>
/// Dto represents the request sent to Api endpoint
/// </summary>
public class MeterReadingsFileDto
{
    /// <summary>
    /// File
    /// </summary>
    [Required(ErrorMessage = "Please upload a meter readings file.")]
    [AllowedFileExtensions(new string[] {".csv"})]
    public IFormFile File { get; set; }
}