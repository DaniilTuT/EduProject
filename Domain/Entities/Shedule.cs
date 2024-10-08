namespace Domain.Entities;

public class Shedule: BaseEntity
{
    public DayOfWeek DayOfWeek { get; set; }
    public Lesson[] Lessons { get; set; }
    public Boolean IsOddWeek { get; set; }

    public void Update(Shedule shedule)
    {
        DayOfWeek = shedule.DayOfWeek;
        Lessons = shedule.Lessons;
        IsOddWeek = shedule.IsOddWeek;
    }
}