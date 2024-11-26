using System.ComponentModel.DataAnnotations;
using Domain.Primitives;
using Domain.Validations.Validators;

namespace Domain.Entities;

public class Shedule: BaseEntity
{
    /// <summary>
    /// Конструктор класса Shedule
    /// </summary>
    /// <param name="dayOfWeek">День недели</param>
    /// <param name="lessons">Список уроков</param>
    /// <param name="isOddWeek">Чётная/нечётная неделя</param>
    public Shedule(DayOfWeek dayOfWeek, Lesson[] lessons, bool isOddWeek)
    {
        DayOfWeek = dayOfWeek;
        Lessons = lessons;
        IsOddWeek = isOddWeek;
        Validate();
    }
    /// <summary>
    /// День недели
    /// </summary>
    public DayOfWeek DayOfWeek { get; set; }
    /// <summary>
    /// Список уроков
    /// </summary>
    public Lesson[] Lessons { get; set; }
    /// <summary>
    /// Чётная/нечётная неделя
    /// </summary>
    public Boolean IsOddWeek { get; set; }
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
        DayOfWeek = shedule.DayOfWeek;
        Lessons = shedule.Lessons;
        IsOddWeek = shedule.IsOddWeek;
    }
}