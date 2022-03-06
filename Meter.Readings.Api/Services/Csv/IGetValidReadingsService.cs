using Meter.Readings.Api.DataAccess;

namespace Meter.Readings.Api.Services.Csv;

public interface IGetValidReadingsService
{
    IEnumerable<MeterReadingModel> GetValidReadings(string meterReadings);
}