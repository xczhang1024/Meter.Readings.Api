using System.Globalization;
using CsvHelper;
using Meter.Readings.Api.DataAccess;
using Meter.Readings.Api.DataAccess.CsvValidation;
using Meter.Readings.Api.Repository;

namespace Meter.Readings.Api.Services.Csv;

public class GetValidReadingsService : IGetValidReadingsService
{
    private readonly IMeterReadingsRepository _repository;

    public GetValidReadingsService(IMeterReadingsRepository repository)
    {
        _repository = repository;
    }
    
    public IEnumerable<MeterReadingModel> GetValidReadings(string meterReadings)
    {
        using var reader = new StringReader(meterReadings);
        using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
        csvReader.Context.RegisterClassMap<MeterReadingMap>();
        
        var readings = csvReader.GetRecords<MeterReadingModel>().ToList();
        
        var validReadings = readings
            .Where(reading => _repository.GetAccount(reading.AccountId) != null)
            .Where(reading =>
                _repository.GetMeterReading(reading.AccountId, 
                    reading.MeterReadingDateTime, 
                    reading.MeterReadValue) == null);

        return validReadings;
    }
}