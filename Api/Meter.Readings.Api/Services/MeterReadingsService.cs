using Meter.Readings.Api.Repository;

namespace Meter.Readings.Api.Services;

/// <summary>
/// Meter readings service
/// </summary>
public class MeterReadingsService : IMeterReadingsService
{
    /// <summary>
    /// The repository
    /// </summary>
    private readonly IMeterReadingsRepository _repository;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="repository">The repository</param>
    public MeterReadingsService(IMeterReadingsRepository repository)
    {
        _repository = repository;
    }
}