using Meter.Readings.Api.Repository;
using Meter.Readings.Api.Services;
using Meter.Readings.Api.Services.Csv;
using Meter.Readings.Data;
using Microsoft.EntityFrameworkCore;

namespace Meter.Readings.Api;

/// <summary>
/// Startup
/// </summary>
public class Startup
{
    /// <summary>
    /// Configuration
    /// </summary>
    private IConfiguration Configuration { get; }
    
    /// <summary>
    /// Startup
    /// </summary>
    /// <param name="configuration"></param>
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    /// <summary>
    /// Configure services
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
        services.AddControllers();
        
        services.AddSwaggerGen();
        
        var connectionString = Configuration.GetConnectionString("Default");
        
        services.AddDbContext<MeterReadingsDbContext>(builder => builder
            .UseSqlServer(connectionString));

        services.AddScoped<IMeterReadingsRepository, MeterReadingsRepository>();
        services.AddTransient<IFileReader, FileReader>();
        services.AddTransient<IGetValidReadingsService, GetValidReadingsService>();
        services.AddTransient<IMeterReadingsService, MeterReadingsService>();
    }
    
    /// <summary>
    /// Configure
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        
        var databaseContext = app.ApplicationServices.CreateScope().ServiceProvider
            .GetRequiredService<MeterReadingsDbContext>();

        databaseContext.Database.Migrate();
        
        app.UseCors(x =>
        {
            x.AllowAnyHeader();
            x.AllowAnyMethod();
            x.AllowCredentials();
            x.WithOrigins("*", "http://localhost:3000");
        });
        
        app.UseHttpsRedirection();
        app.UseRouting();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}