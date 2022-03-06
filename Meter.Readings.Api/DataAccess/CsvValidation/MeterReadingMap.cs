using CsvHelper.Configuration;

namespace Meter.Readings.Api.DataAccess.CsvValidation;

public sealed class MeterReadingMap : ClassMap<MeterReadingModel>
{
    public MeterReadingMap()
    {
        Map(mr => mr.AccountId);
        Map(mr => mr.MeterReadingDateTime);
        Map(mr => mr.MeterReadValue)
            .Validate(x => x.Field.Length == 5)
            .Validate(x => int.TryParse(x.Field, out _));
    }
}