using Meter.Readings.Api.DataAccess;

namespace Meter.Readings.Api.Services.Csv;

/// <summary>
/// Service to parse Csv into valid objects
/// </summary>
public interface ICsvParsingService
{
    /// <summary>
    /// Method to parse Csv
    /// </summary>
    /// <param name="pathToCsvFile">Path to Csv file</param>
    /// <returns></returns>
    IReadOnlyCollection<MeterReadingCsvLineDto> ParseCsv(string pathToCsvFile);
}