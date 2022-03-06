using System.IO;
using Meter.Readings.Api.Services.Csv;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace Meter.Readings.Api.Tests;

public class FileReaderShould
{
    [Fact]
    public async void GetContentsOfFileAsString()
    {
        // Arrange
        var fileMock = new Mock<IFormFile>();
        const string content = "AccountId,MeterReadingDateTime,MeterReadValue" + "\r\n" +
                               "2344,22/04/2019 09:24,01002\r\n";
        const string fileName = "test.csv";
        var ms = new MemoryStream();
        var writer = new StreamWriter(ms);
        writer.Write(content);
        writer.Flush();
        ms.Position = 0;
        fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
        fileMock.Setup(_ => _.FileName).Returns(fileName);
        fileMock.Setup(_ => _.Length).Returns(ms.Length);

        var sut = new FileReader();
        var file = fileMock.Object;
        
        // Act
        var fileContent = await sut.ReadFileToString(file);

        // Assert
        Assert.Equal(content, fileContent.ToString());
    }
}