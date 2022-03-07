namespace Meter.Readings.Api.Services.Csv;

/// <summary>
/// File reader reads file to string
/// </summary>
public interface IFileReader
{
    /// <summary>
    /// Read file to string
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    Task<string> ReadFileToString(IFormFile file);
}