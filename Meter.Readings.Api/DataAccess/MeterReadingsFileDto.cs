using System.ComponentModel.DataAnnotations;
using Meter.Readings.Api.DataAccess.ValidationAttributes;

namespace Meter.Readings.Api.DataAccess;

public class MeterReadingsFileDto
{
    [Required(ErrorMessage = "Please upload a meter readings file.")]
    [AllowedFileExtensions(new string[] {".csv"})]
    public IFormFile File { get; set; }
}