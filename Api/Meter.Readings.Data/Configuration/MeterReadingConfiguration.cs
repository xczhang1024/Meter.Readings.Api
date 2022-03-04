using Meter.Readings.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meter.Readings.Data.Configuration;

public class MeterReadingConfiguration : IEntityTypeConfiguration<MeterReading>
{
    public void Configure(EntityTypeBuilder<MeterReading> builder)
    {
        builder.HasKey(mr => mr.Id);

        builder.Property(mr => mr.DateTime).IsRequired();
        builder.Property(mr => mr.Value).IsRequired();
    }
}