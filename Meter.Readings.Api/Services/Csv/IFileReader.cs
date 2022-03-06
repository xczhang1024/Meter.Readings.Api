namespace Meter.Readings.Api.Services.Csv;

public interface IFileReader
{
    Task<string> ReadFileToString(IFormFile file);
}