namespace Domain.ValueObjects;

public class DateRange
{
    /// <summary>
    /// Время начала
    /// </summary>
    public DateTime StartDate { get; set; } 
    /// <summary>
    /// Время конца
    /// </summary>
    public DateTime EndDate { get; set; }
}