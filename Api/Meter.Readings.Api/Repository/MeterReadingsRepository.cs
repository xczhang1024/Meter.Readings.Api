using Meter.Readings.Api.DataAccess;
using Meter.Readings.Data;
using Meter.Readings.Data.Models;

namespace Meter.Readings.Api.Repository;

/// <summary>
/// Blog post repository
/// </summary>
public class MeterReadingsRepository : IMeterReadingsRepository
{
    /// <summary>
    /// Db context
    /// </summary>
    private readonly MeterReadingsDbContext _db;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="db"></param>
    public MeterReadingsRepository(MeterReadingsDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// Insert meter readings into the database
    /// </summary>
    /// <param name="readings">Validated meter readings</param>
    /// <returns></returns>
    public async Task CreateMeterReadings(IEnumerable<MeterReadingCsvLineDto> readings)
    {
        
    }
}