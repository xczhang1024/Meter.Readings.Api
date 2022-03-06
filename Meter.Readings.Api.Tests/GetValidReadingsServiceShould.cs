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
    public async void IncrementFailedReadingsWhenColumnsCountIsIncorrect()
    {
        const string content = "AccountId,MeterReadingDateTime,MeterReadValue" + "\n" +
                               "2344,22/04/2019 09:24,01002,X\n" +
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
        
        Assert.Equal(2, readings.NumberOfFailedMeterReadings);
        Assert.Single(readings.ValidMeterReadings);
    }
}