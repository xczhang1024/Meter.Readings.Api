using Meter.Readings.Api.DataAccess;

namespace Meter.Readings.Api.Services.Csv;

public interface IGetValidReadingsService
{
    Task<ValidMeterReadingsModel> GetValidReadings(string meterReadings);
}