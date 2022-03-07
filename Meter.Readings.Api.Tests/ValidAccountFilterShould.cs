using System;
using System.Collections.Generic;
using Meter.Readings.Api.DataAccess;
using Meter.Readings.Api.Repository;
using Meter.Readings.Api.Services.Csv.Filters;
using Meter.Readings.Data;
using Meter.Readings.Data.Models;
using Moq;
using Moq.EntityFrameworkCore;
using Xunit;
namespace Meter.Readings.Api.Tests;

public class ValidAccountFilterShould
{
    [Fact]
    public async void RemoveReadingsWithInvalidAccountId()
    {
        var dbContextMock = new Mock<MeterReadingsDbContext>();
        
        IList<Account> accounts = new List<Account>()
        {
            new() { AccountId = 123, FirstName = "Jim", LastName = "Test" },
            new() { AccountId = 456, FirstName = "Bob", LastName = "Test" }
        };
        dbContextMock.Setup(x => x.Accounts)
            .ReturnsDbSet(accounts);
        
        var meterReadings = new List<MeterReadingModel>()
        {
            new() { AccountId = 444, MeterReadValue = "44444", MeterReadingDateTime = DateTime.Now }
        };

        var repository = new MeterReadingsRepository(dbContextMock.Object);
        var sut = new InvalidAccountFilter(repository);

        meterReadings = await sut.Filter(meterReadings);

        Assert.Empty(meterReadings);
    }
    
    [Fact]
    public async void KeepReadingsWithValidAccountId()
    {
        var dbContextMock = new Mock<MeterReadingsDbContext>();
        
        IList<Account> accounts = new List<Account>()
        {
            new() { AccountId = 123, FirstName = "Jim", LastName = "Test" },
            new() { AccountId = 456, FirstName = "Bob", LastName = "Test" }
        };
        dbContextMock.Setup(x => x.Accounts)
            .ReturnsDbSet(accounts);
        
        var meterReadings = new List<MeterReadingModel>()
        {
            new() { AccountId = 123, MeterReadValue = "44444", MeterReadingDateTime = DateTime.Now },
            new() { AccountId = 456, MeterReadValue = "55555", MeterReadingDateTime = DateTime.Now }
        };

        var repository = new MeterReadingsRepository(dbContextMock.Object);
        var sut = new InvalidAccountFilter(repository);

        meterReadings = await sut.Filter(meterReadings);

        Assert.True(meterReadings.Count == 2);
    }
}