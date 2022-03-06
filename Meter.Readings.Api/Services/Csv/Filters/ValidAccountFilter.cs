using Meter.Readings.Api.DataAccess;
using Meter.Readings.Api.Repository;

namespace Meter.Readings.Api.Services.Csv.Filters;

public class ValidAccountFilter : IMeterReadingsFilter
{
    private readonly IMeterReadingsRepository _repository;
    
    public ValidAccountFilter(IMeterReadingsRepository repository)
    {
        _repository = repository;
    }
    
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