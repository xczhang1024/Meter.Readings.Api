using Meter.Readings.Api.DataAccess;
using Meter.Readings.Api.Repository;

namespace Meter.Readings.Api.Services.Csv.Filters;

/// <summary>
/// Filter out readings from invalid accounts
/// </summary>
public class InvalidAccountFilter : IMeterReadingsFilter
{
    /// <summary>
    /// Repository
    /// </summary>
    private readonly IMeterReadingsRepository _repository;
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="repository"></param>
    public InvalidAccountFilter(IMeterReadingsRepository repository)
    {
        _repository = repository;
    }
    
    /// <summary>
    /// Filter out invalid readings, leaving only valid readings
    /// </summary>
    /// <param name="meterReadings"></param>
    /// <returns></returns>
    public async Task<List<MeterReadingModel>> Filter(List<MeterReadingModel> meterReadings)
    {
        var accountIds = meterReadings.Select(reading => reading.AccountId);
        var validAccountIds = (await _repository.GetAccounts(accountIds))
            .Select(account => account.AccountId);

        return  meterReadings
            .Where(reading => validAccountIds.Contains(reading.AccountId))
            .ToList();
    }
}