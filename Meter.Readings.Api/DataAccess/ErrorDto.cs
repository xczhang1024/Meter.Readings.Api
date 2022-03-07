namespace Meter.Readings.Api.DataAccess;

/// <summary>
/// Dto for API errors
/// </summary>
public class ErrorDto
{
    /// <summary>
    /// User-friendly message
    /// </summary>
    public string Message { get; set; }
    
    /// <summary>
    /// Exception message
    /// </summary>
    public string ExceptionMessage { get; set; }
}