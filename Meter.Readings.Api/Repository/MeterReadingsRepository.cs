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

    public async Task<Account> GetAccount(int accountId)
    {
        return await _db.Accounts.FindAsync(accountId);
    }

    public async Task<MeterReading> GetMeterReading(int accountId, DateTime dateTime, string value)
    {
        return await _db.MeterReadings.Where(mr =>
            mr.AccountId == accountId 
            && mr.DateTime == dateTime 
            && mr.Value == value).FirstOrDefaultAsync();
    }
    
    public async Task AddMeterReadings(IEnumerable<MeterReadingModel> readings)
    {
        
    }
}