namespace Meter.Readings.Data.Models;

/// <summary>
/// Represents a meter reading
/// </summary>
public class MeterReading
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Date time of meter reading
    /// </summary>
    public DateTime DateTime { get; set; }

    /// <summary>
    /// Value of meter reading
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// Account for meter reading
    /// </summary>
    public Account Account { get; set; }
}