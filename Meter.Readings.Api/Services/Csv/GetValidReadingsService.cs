using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Meter.Readings.Api.DataAccess;
using Meter.Readings.Api.Repository;
using Meter.Readings.Api.Services.Csv.Filters;

namespace Meter.Readings.Api.Services.Csv;

/// <summary>
/// Service for getting valid readings
/// </summary>
public class GetValidReadingsService : IGetValidReadingsService
{
    /// <summary>
    /// Repository
    /// </summary>
    private readonly IMeterReadingsRepository _repository;

    /// <summary>
    /// List of filters
    /// </summary>
    private readonly List<IMeterReadingsFilter> _meterReadingsFilters;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="repository"></param>
    public GetValidReadingsService(IMeterReadingsRepository repository)
    {
        _repository = repository;
        _meterReadingsFilters = new List<IMeterReadingsFilter>()
        {
            new InvalidFormatFilter(),
            new InvalidAccountFilter(_repository),
            new NoDuplicationFilter(_repository)
        };
    }
    
    /// <summary>
    /// Get valid readings from csv string
    /// </summary>
    /// <param name="meterReadings"></param>
    /// <returns></returns>
    public async Task<ValidMeterReadingsModel> GetValidReadings(string meterReadings)
    {
        var config = new CsvConfiguration(CultureInfo.GetCultureInfo("en-GB"))
        {
            HasHeaderRecord = true
        };
        
        using var reader = new StringReader(meterReadings);
        using var csvReader = new CsvReader(reader, config);

        var readings = new List<MeterReadingModel>();
        var totalLines = 0;

        // Have to read one by one
        // otherwise one bad record will cause the whole file to fail
        while (await csvReader.ReadAsync())
        {
            totalLines++;
            
            try
            {
                var record = csvReader.GetRecord<MeterReadingModel>();
                Console.WriteLine(csvReader.ColumnCount);
                readings.Add(record);
            }
            catch (BadDataException bde)
            {
                // TODO: In production, log this exception
            }
            catch (Exception e)
            {
                // TODO: In production, log this exception
            }
        }

        foreach (var filter in _meterReadingsFilters)
        {
            readings = await filter.Filter(readings);
        }

        return new ValidMeterReadingsModel()
        {
            ValidMeterReadings = readings,
            NumberOfFailedMeterReadings = totalLines - readings.Count
        };
    }
}