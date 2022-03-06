namespace Meter.Readings.Data.Models;

/// <summary>
/// Account
/// </summary>
public class Account
{
    /// <summary>
    /// Account Id
    /// </summary>
    public int AccountId { get; init; }
    
    /// <summary>
    /// First Name
    /// </summary>
    public string FirstName { get; init; }
    
    /// <summary>
    /// Last Name
    /// </summary>
    public string LastName { get; init; }
    
    /// <summary>
    /// Meter readings belonging to account
    /// </summary>
    public virtual List<MeterReading> MeterReadings { get; set; }
}