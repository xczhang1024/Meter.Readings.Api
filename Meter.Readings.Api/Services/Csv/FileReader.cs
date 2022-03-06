using System.Text;

namespace Meter.Readings.Api.Services.Csv;

public class FileReader : IFileReader
{
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