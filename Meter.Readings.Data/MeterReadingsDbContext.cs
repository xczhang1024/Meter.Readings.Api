using Meter.Readings.Data.Configuration;
using Meter.Readings.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Meter.Readings.Data;

public class MeterReadingsDbContext : DbContext
{
    public virtual DbSet<Account> Accounts { get; set; }
    
    public virtual DbSet<MeterReading> MeterReadings { get; set; }

    public MeterReadingsDbContext()
    {
    }

    public MeterReadingsDbContext(DbContextOptions<MeterReadingsDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MeterReadingConfiguration());
        modelBuilder.ApplyConfiguration(new AccountConfiguration());

        modelBuilder.Entity<Account>()
            .HasMany(a => a.MeterReadings)
            .WithOne(mr => mr.Account)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Account>().HasData(
            new Account { AccountId = 2344, FirstName = "Tommy", LastName = "Test" },
            new Account { AccountId = 2233, FirstName = "Barry", LastName = "Test" },
            new Account { AccountId = 8766, FirstName = "Sally", LastName = "Test" },
            new Account { AccountId = 2345, FirstName = "Jerry", LastName = "Test" },
            new Account { AccountId = 2346, FirstName = "Ollie", LastName = "Test" },
            new Account { AccountId = 2347, FirstName = "Tara", LastName = "Test" },
            new Account { AccountId = 2348, FirstName = "Tammy", LastName = "Test" },
            new Account { AccountId = 2349, FirstName = "Simon", LastName = "Test" },
            new Account { AccountId = 2350, FirstName = "Colin", LastName = "Test" },
            new Account { AccountId = 2351, FirstName = "Gladys", LastName = "Test" },
            new Account { AccountId = 2352, FirstName = "Greg", LastName = "Test" },
            new Account { AccountId = 2353, FirstName = "Tony", LastName = "Test" },
            new Account { AccountId = 2355, FirstName = "Arthur", LastName = "Test" },
            new Account { AccountId = 2356, FirstName = "Greg", LastName = "Test" },
            new Account { AccountId = 6776, FirstName = "Laura", LastName = "Test" },
            new Account { AccountId = 4534, FirstName = "JOSH", LastName = "TEST" },
            new Account { AccountId = 1234, FirstName = "Freya", LastName = "TEST" },
            new Account { AccountId = 1239, FirstName = "Noddy", LastName = "TEST" },
            new Account { AccountId = 1240, FirstName = "Archie", LastName = "TEST" },
            new Account { AccountId = 1241, FirstName = "Lara", LastName = "TEST" },
            new Account { AccountId = 1243, FirstName = "Graham", LastName = "TEST" },
            new Account { AccountId = 1244, FirstName = "Tony", LastName = "TEST" },
            new Account { AccountId = 1245, FirstName = "Neville", LastName = "TEST" },
            new Account { AccountId = 1246, FirstName = "Jo", LastName = "TEST" },
            new Account { AccountId = 1247, FirstName = "Jim", LastName = "TEST" },
            new Account { AccountId = 1248, FirstName = "Pam", LastName = "TEST" }
        );

        base.OnModelCreating(modelBuilder);
    }
}