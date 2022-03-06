using Meter.Readings.Api.DataAccess;
using Meter.Readings.Data.Models;

namespace Meter.Readings.Api.Repository;

/// <summary>
/// Interface for meter readings repository
/// </summary>
public interface IMeterReadingsRepository
{
    Task<Account> GetAccount(int accountId);
    
    Task<MeterReading> GetMeterReading(int accountId, DateTime dateTime, string value);
    
    Task AddMeterReadings(IEnumerable<MeterReadingModel> readings);
}