using Meter.Readings.Api.DataAccess;
using Meter.Readings.Data.Models;

namespace Meter.Readings.Api.Repository;

/// <summary>
/// Interface for meter readings repository
/// </summary>
public interface IMeterReadingsRepository
{
    Task<List<Account>> GetAccounts(IEnumerable<int> accountIds);
    
    Task<MeterReading> GetMeterReading(int accountId, DateTime dateTime, string value);
    
    Task AddMeterReadings(IEnumerable<MeterReadingModel> readings);
}