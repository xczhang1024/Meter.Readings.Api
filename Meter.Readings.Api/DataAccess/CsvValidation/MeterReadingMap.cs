using CsvHelper.Configuration;

namespace Meter.Readings.Api.DataAccess.CsvValidation;

public sealed class MeterReadingMap : ClassMap<MeterReadingModel>
{
    public MeterReadingMap()
    {
        Map(mr => mr.AccountId).Name("AccountId");
        Map(mr => mr.MeterReadingDateTime).Name("MeterReadingDateTime");
        Map(mr => mr.MeterReadValue).Name("MeterReadValue")
            .Validate(x => x.Field.Length == 5)
            .Validate(x => int.TryParse(x.Field, out var reading) && reading > 0);
    }
}