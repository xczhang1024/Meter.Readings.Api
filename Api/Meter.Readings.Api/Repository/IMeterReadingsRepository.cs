using Meter.Readings.Api.DataAccess;
using Meter.Readings.Data.Models;

namespace Meter.Readings.Api.Repository;

/// <summary>
/// Interface for meter readings repository
/// </summary>
public interface IMeterReadingsRepository
{
    /// <summary>
    /// Insert meter readings into the database
    /// </summary>
    /// <param name="readings">Validated meter readings</param>
    /// <returns></returns>
    Task CreateMeterReadings(IEnumerable<MeterReadingCsvLineDto> readings);
}