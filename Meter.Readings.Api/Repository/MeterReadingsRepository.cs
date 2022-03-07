using Meter.Readings.Api.DataAccess;
using Meter.Readings.Data;
using Meter.Readings.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Meter.Readings.Api.Repository;

/// <summary>
/// Repository for meter readings allows database access
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
    /// Get account entities which are in the list of accountIds
    /// </summary>
    /// <param name="accountIds"></param>
    /// <returns></returns>
    public async Task<List<Account>> GetAccounts(IEnumerable<int> accountIds)
    {
        return await _db.Accounts
            .AsNoTracking()
            .Where(a => accountIds.Contains(a.AccountId))
            .ToListAsync();
    }

    /// <summary>
    /// Get a meter reading
    /// </summary>
    /// <param name="accountId"></param>
    /// <param name="dateTime"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public async Task<MeterReading> GetMeterReading(int accountId, DateTime dateTime, string value)
    {
        return await _db.MeterReadings
            .AsNoTracking()
            .Include(mr => mr.Account)
            .Where(mr =>
            mr.Account.AccountId == accountId
            && mr.DateTime == dateTime 
            && mr.Value == value).FirstOrDefaultAsync();
    }
    
    /// <summary>
    /// Add a list of meter readings
    /// </summary>
    /// <param name="readings"></param>
    /// <returns></returns>
    public async Task AddMeterReadings(IEnumerable<MeterReadingModel> readings)
    {
        var models = readings.Select(r => new MeterReading()
        {
            AccountId = r.AccountId,
            DateTime = r.MeterReadingDateTime,
            Value = r.MeterReadValue
        });

        await _db.AddRangeAsync(models);
        await _db.SaveChangesAsync();
    }
}