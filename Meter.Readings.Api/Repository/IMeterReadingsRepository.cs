using Meter.Readings.Api.DataAccess;
using Meter.Readings.Data.Models;

namespace Meter.Readings.Api.Repository;

/// <summary>
/// Repository for meter readings allows database access
/// </summary>
public interface IMeterReadingsRepository
{
    /// <summary>
    /// Get account entities which are in the list of accountIds
    /// </summary>
    /// <param name="accountIds"></param>
    /// <returns></returns>
    Task<List<Account>> GetAccounts(IEnumerable<int> accountIds);
    
    /// <summary>
    /// Get a meter reading
    /// </summary>
    /// <param name="accountId"></param>
    /// <param name="dateTime"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    Task<MeterReading> GetMeterReading(int accountId, DateTime dateTime, string value);
    
    /// <summary>
    /// Add a list of meter readings
    /// </summary>
    /// <param name="readings"></param>
    /// <returns></returns>
    Task AddMeterReadings(IEnumerable<MeterReadingModel> readings);
}