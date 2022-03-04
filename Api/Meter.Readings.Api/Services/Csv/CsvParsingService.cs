using System.Globalization;
using CsvHelper;
using Meter.Readings.Api.DataAccess;

namespace Meter.Readings.Api.Services.Csv;

public class CsvParsingService : ICsvParsingService
{
    /// <summary>
    /// Method to parse Csv
    /// </summary>
    /// <param name="pathToCsvFile">Path to Csv file</param>
    /// <returns></returns>
    public IReadOnlyCollection<MeterReadingCsvLineDto> ParseCsv(string pathToCsvFile)
    {
        using var reader = new StreamReader(pathToCsvFile);
        using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

        return csvReader.GetRecords<MeterReadingCsvLineDto>().ToList();
    }
}