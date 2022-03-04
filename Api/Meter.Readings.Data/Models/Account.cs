namespace Meter.Readings.Data.Models;

/// <summary>
/// Account
/// </summary>
public class Account
{
    /// <summary>
    /// Account Id
    /// </summary>
    public int AccountId { get; set; }
    
    /// <summary>
    /// First Name
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// Last Name
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// Meter readings belonging to account
    /// </summary>
    public virtual List<MeterReading> MeterReadings { get; set; }
}