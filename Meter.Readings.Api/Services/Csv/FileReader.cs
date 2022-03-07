using System.Text;

namespace Meter.Readings.Api.Services.Csv;

/// <summary>
/// File reader reads file to string
/// </summary>
public class FileReader : IFileReader
{
    /// <summary>
    /// Read file to string
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public async Task<string> ReadFileToString(IFormFile file)
    {
        var result = new StringBuilder();
        using (var reader = new StreamReader(file.OpenReadStream()))
        {
            while (reader.Peek() >= 0)
            {
                result.AppendLine(await reader.ReadLineAsync()); 
            }
        }
        return result.ToString();
    }
}