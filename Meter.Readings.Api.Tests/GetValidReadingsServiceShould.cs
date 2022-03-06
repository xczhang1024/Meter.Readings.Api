using System;
using System.Collections.Generic;
using System.Linq;
using Meter.Readings.Api.Repository;
using Meter.Readings.Api.Services.Csv;
using Meter.Readings.Data;
using Meter.Readings.Data.Models;
using Moq;
using Moq.EntityFrameworkCore;
using Xunit;

namespace Meter.Readings.Api.Tests;

public class GetValidReadingsServiceShould
{
    [Fact]
    public async void IncrementFailedReadingsCountWhenColumnsCountIsIncorrect()
    {
        const string content = "AccountId,MeterReadingDateTime,MeterReadValue" + "\n" +
                               "2344,22/04/2019 09:24,01002\n" +
                               "2344,22/04/2019 09:24,\n" +
                               "2344,22/04/2019 09:24,11111\n";
        
        var dbContextMock = new Mock<MeterReadingsDbContext>();
        IList<Account> accounts = new List<Account>()
        {
            new() { AccountId = 2344, FirstName = "Jim", LastName = "Test" }
        };
        
        IList<MeterReading> meterReadings = new List<MeterReading>();
        
        dbContextMock.Setup(x => x.Accounts)
            .ReturnsDbSet(accounts);
        dbContextMock.Setup(x => x.MeterReadings)
            .ReturnsDbSet(meterReadings);

        var repository = new MeterReadingsRepository(dbContextMock.Object);
        var sut = new GetValidReadingsService(repository);

        var readings = await sut.GetValidReadings(content);
        
        Assert.Equal(1, readings.NumberOfFailedMeterReadings);
        Assert.Equal(2, readings.ValidMeterReadings.Count());
    }

    [Fact]
    public async void IncrementFailedReadingsCountWhenAccountsDoNotExist()
    {
        const string content = "AccountId,MeterReadingDateTime,MeterReadValue" + "\n" +
                               "2344,22/04/2019 09:24,00115\n" +
                               "2345,22/04/2019 09:24,00111\n" +
                               "2344,22/04/2019 09:28,00116\n";
        
        var dbContextMock = new Mock<MeterReadingsDbContext>();
        IList<Account> accounts = new List<Account>()
        {
            new() { AccountId = 2344, FirstName = "Jim", LastName = "Test" }
        };
        
        IList<MeterReading> meterReadings = new List<MeterReading>();
        
        dbContextMock.Setup(x => x.Accounts)
            .ReturnsDbSet(accounts);
        dbContextMock.Setup(x => x.MeterReadings)
            .ReturnsDbSet(meterReadings);

        var repository = new MeterReadingsRepository(dbContextMock.Object);
        var sut = new GetValidReadingsService(repository);

        var readings = await sut.GetValidReadings(content);
        
        Assert.Equal(1, readings.NumberOfFailedMeterReadings);
        Assert.Equal(2, readings.ValidMeterReadings.Count());
        Assert.Equal(2344, readings.ValidMeterReadings.First().AccountId);
        Assert.Equal(2344, readings.ValidMeterReadings.Last().AccountId);
    }

    [Fact]
    public async void IncrementFailedReadingsCountWhenMeterReadingIsDuplicated()
    {
        const string content = "AccountId,MeterReadingDateTime,MeterReadValue" + "\n" +
                               "2344,22/04/2019 09:24,00115\n" +
                               "2344,22/04/2019 09:28,00116\n";
        
        var dbContextMock = new Mock<MeterReadingsDbContext>();
        IList<Account> accounts = new List<Account>()
        {
            new() { AccountId = 2344, FirstName = "Jim", LastName = "Test" }
        };

        IList<MeterReading> meterReadings = new List<MeterReading>()
        {
            new()
            {
                Id = 1,
                Account = accounts[0],
                DateTime = DateTime.Parse("22/04/2019 09:28"),
                Value = "00116"
            }
        };
        
        dbContextMock.Setup(x => x.Accounts)
            .ReturnsDbSet(accounts);
        dbContextMock.Setup(x => x.MeterReadings)
            .ReturnsDbSet(meterReadings);
        
        var repository = new MeterReadingsRepository(dbContextMock.Object);
        var sut = new GetValidReadingsService(repository);
        
        var readings = await sut.GetValidReadings(content);
        
        Assert.Equal(1, readings.NumberOfFailedMeterReadings);
        Assert.Single(readings.ValidMeterReadings);
        Assert.Equal("00115", readings.ValidMeterReadings.First().MeterReadValue);
    }
}