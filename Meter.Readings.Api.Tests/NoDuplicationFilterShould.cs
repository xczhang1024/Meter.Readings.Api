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

public class NoDuplicationFilterShould
{
    [Fact]
    public async void RemoveDuplicateMeterReading()
    {
        var dbContextMock = new Mock<MeterReadingsDbContext>();
        
        IList<Account> accounts = new List<Account>()
        {
            new() { AccountId = 123, FirstName = "Jim", LastName = "Test" }
        };

        var meterReading = new MeterReading()
        {
            Id = 1,
            Account = accounts[0],
            DateTime = DateTime.Now,
            Value = "33333"
        };

        IList<MeterReading> meterReadings = new List<MeterReading>() { meterReading };

        dbContextMock.Setup(x => x.Accounts)
            .ReturnsDbSet(accounts);
        dbContextMock.Setup(x => x.MeterReadings)
            .ReturnsDbSet(meterReadings);
        
        var meterReadingModels = new List<MeterReadingModel>()
        {
            new()
            {
                AccountId = 123, 
                MeterReadValue = meterReading.Value, 
                MeterReadingDateTime = meterReading.DateTime
            }
        };
        
        var repository = new MeterReadingsRepository(dbContextMock.Object);
        var sut = new NoDuplicationFilter(repository);

        meterReadingModels = await sut.Filter(meterReadingModels);
        
        Assert.Empty(meterReadingModels);
    }
    
    [Fact]
    public async void KeepNonDuplicateMeterReading()
    {
        var dbContextMock = new Mock<MeterReadingsDbContext>();
        
        IList<Account> accounts = new List<Account>()
        {
            new() { AccountId = 123, FirstName = "Jim", LastName = "Test" }
        };

        var meterReading = new MeterReading()
        {
            Id = 1,
            Account = accounts[0],
            DateTime = DateTime.Now,
            Value = "33333"
        };

        IList<MeterReading> meterReadings = new List<MeterReading>() { meterReading };

        dbContextMock.Setup(x => x.Accounts)
            .ReturnsDbSet(accounts);
        dbContextMock.Setup(x => x.MeterReadings)
            .ReturnsDbSet(meterReadings);
        
        var meterReadingModels = new List<MeterReadingModel>()
        {
            new()
            {
                AccountId = 123, 
                MeterReadValue = "44444", 
                MeterReadingDateTime = meterReading.DateTime
            }
        };
        
        var repository = new MeterReadingsRepository(dbContextMock.Object);
        var sut = new NoDuplicationFilter(repository);

        meterReadingModels = await sut.Filter(meterReadingModels);
        
        Assert.Single(meterReadingModels);
    }
}