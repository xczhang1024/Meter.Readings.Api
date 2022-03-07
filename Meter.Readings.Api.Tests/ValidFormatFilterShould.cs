using System;
using System.Collections.Generic;
using Meter.Readings.Api.DataAccess;
using Meter.Readings.Api.Services.Csv.Filters;
using Xunit;
namespace Meter.Readings.Api.Tests;

public class ValidFormatFilterShould
{
    [Fact]
    public async void RejectInvalidLengthMeterReadings()
    {
        var meterReadings = new List<MeterReadingModel>()
        {
            new() { AccountId = 1, MeterReadValue = "4444", MeterReadingDateTime = DateTime.Now }
        };

        var sut = new InvalidFormatFilter();
        meterReadings = await sut.Filter(meterReadings);
        
        Assert.Empty(meterReadings);
    }

    [Fact]
    public async void RejectNonNumericMeterReadings()
    {
        var meterReadings = new List<MeterReadingModel>()
        {
            new() { AccountId = 1, MeterReadValue = "AA", MeterReadingDateTime = DateTime.Now }
        };

        var sut = new InvalidFormatFilter();
        meterReadings = await sut.Filter(meterReadings);
        
        Assert.Empty(meterReadings);
    }
    
    [Fact]
    public async void AcceptCorrectMeterReading()
    {
        var meterReadings = new List<MeterReadingModel>()
        {
            new() { AccountId = 1, MeterReadValue = "12345", MeterReadingDateTime = DateTime.Now }
        };

        var sut = new InvalidFormatFilter();
        meterReadings = await sut.Filter(meterReadings);
        
        Assert.Single(meterReadings);
    }
}