using Meter.Readings.Api.DataAccess;

namespace Meter.Readings.Api.Services.Csv.Filters;

public interface IMeterReadingsFilter
{
    Task<List<MeterReadingModel>> Filter(List<MeterReadingModel> meterReadings);
}