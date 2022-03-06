using Meter.Readings.Api.DataAccess;
using Meter.Readings.Data.Models;

namespace Meter.Readings.Api.Repository;

public interface IMeterReadingsRepository
{
    Task<List<Account>> GetAccounts(IEnumerable<int> accountIds);
    
    Task<MeterReading> GetMeterReading(int accountId, DateTime dateTime, string value);
    
    Task AddMeterReadings(IEnumerable<MeterReadingModel> readings);
}