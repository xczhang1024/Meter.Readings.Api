using System;
using System.Collections.Generic;
using System.Linq;
using Meter.Readings.Api.Repository;
using Meter.Readings.Data;
using Meter.Readings.Data.Models;
using Moq;
using Moq.EntityFrameworkCore;
using Xunit;

namespace Meter.Readings.Api.Tests;

public class MeterReadingsRepositoryShould
{
    [Fact]
    public async void GetAccountsWhichExist()
    {
        // Arrange
        var dbContextMock = new Mock<MeterReadingsDbContext>();
        
        IList<Account> accounts = new List<Account>()
        {
           new() { AccountId = 123, FirstName = "Jim", LastName = "Test" },
           new() { AccountId = 456, FirstName = "Bob", LastName = "Test" }
        };
        dbContextMock.Setup(x => x.Accounts)
            .ReturnsDbSet(accounts);

        var sut = new MeterReadingsRepository(dbContextMock.Object);
        // Act
        var accountFromDb = await sut.GetAccounts(new List<int>() { 123 });

        // Assert
        Assert.Single(accountFromDb);
        Assert.True(accountFromDb.First().AccountId == 123);
    }

    [Fact]
    public async void GetMeterReadingThatExists()
    {
        // Arrange
        var dbContextMock = new Mock<MeterReadingsDbContext>();
        var meterReading = new MeterReading()
        {
            Id = 1, 
            DateTime = DateTime.Now,
            Account = new Account()
            {
                AccountId = 123,
                FirstName = "Jim",
                LastName = "Test"
            }
        };
        
        IList<MeterReading> readings = new List<MeterReading>() { meterReading };
        dbContextMock.Setup(x => x.MeterReadings)
            .ReturnsDbSet(readings);
        
        var sut = new MeterReadingsRepository(dbContextMock.Object);
        // Act
        var readingFromDb = await sut.GetMeterReading(meterReading.Account.AccountId, 
            meterReading.DateTime, 
            meterReading.Value);
        
        // Assert
        Assert.Equal(meterReading, readingFromDb);
    }
    
    [Fact]
    public async void FailToGetMeterReadingThatDoesNotExist()
    {
        // Arrange
        var dbContextMock = new Mock<MeterReadingsDbContext>();
        var meterReading = new MeterReading()
        {
            Id = 1, 
            DateTime = DateTime.Now,
            Account = new Account()
            {
                AccountId = 123,
                FirstName = "Jim",
                LastName = "Test"
            }
        };
        
        IList<MeterReading> readings = new List<MeterReading>() { meterReading };
        dbContextMock.Setup(x => x.MeterReadings)
            .ReturnsDbSet(readings);
        
        var sut = new MeterReadingsRepository(dbContextMock.Object);
        // Act
        var readingFromDb = await sut.GetMeterReading(meterReading.AccountId + 1, 
            meterReading.DateTime, 
            meterReading.Value);
        
        // Assert
        Assert.Null(readingFromDb);
    }
}