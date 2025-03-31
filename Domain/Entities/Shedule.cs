using System.ComponentModel.DataAnnotations;
using Domain.Primitives;
using Domain.Validations.Validators;

namespace Domain.Entities;

public class Shedule: BaseEntity
{
    public Shedule(){}
    /// <summary>
    /// Конструктор класса Shedule
    /// </summary>
    /// <param name="dayOfWeek">День недели</param>
    /// <param name="lessons">Список уроков</param>
    /// <param name="isOddWeek">Чётная/нечётная неделя</param>
    public Shedule(DayOfWeek day, List<Lesson> lessons, bool isOddWeek,Group group)
    {
        Group = group;
        Day = day;
        Lessons = lessons;
        IsOddWeek = isOddWeek;
        GroupId = group.Id;
        
        
        Validate();
    }

    /// <summary>
    /// День недели
    /// </summary>
    public DayOfWeek Day { get; set; }
    /// <summary>
    /// Список уроков
    /// </summary>
    public List<Lesson> Lessons { get; set; }
    /// <summary>
    /// Чётная/нечётная неделя
    /// </summary>
    public Boolean IsOddWeek { get; set; }
    
    public Guid GroupId { get; set; }
    public Group Group { get; set; }
    
    /// <summary>
    /// Валидация класса Shedule 
    /// </summary>

    private void Validate()
    {
        var validate = new SheduleValidator();
        validate.Validate(this);
    }
    /// <summary>
    /// Метод обновления экземпляра класса Shedule
    /// </summary>
    /// <param name="shedule">Экземпляр класса Shedule</param>
    public void Update(Shedule shedule)
    {
        Day = shedule.Day;
        Lessons = shedule.Lessons;
        IsOddWeek = shedule.IsOddWeek;
        GroupId = shedule.GroupId;
        Group = shedule.Group;
    }
}