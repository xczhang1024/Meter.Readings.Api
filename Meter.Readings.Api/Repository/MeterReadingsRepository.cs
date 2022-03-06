using Meter.Readings.Api.DataAccess;
using Meter.Readings.Data;
using Meter.Readings.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Meter.Readings.Api.Repository;

public class MeterReadingsRepository : IMeterReadingsRepository
{
    private readonly MeterReadingsDbContext _db;
    
    public MeterReadingsRepository(MeterReadingsDbContext db)
    {
        _db = db;
    }

    public async Task<List<Account>> GetAccounts(IEnumerable<int> accountIds)
    {
        return await _db.Accounts
            .AsNoTracking()
            .Where(a => accountIds.Contains(a.AccountId))
            .ToListAsync();
    }

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