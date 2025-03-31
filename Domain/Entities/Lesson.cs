using Domain.Primitives.Enums;
using Domain.Validations.Validators;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Lesson:BaseEntity
{
    public Lesson(){}
    public Lesson(Shedule shedule)
    {
        Shedule = shedule;
    }
    /// <summary>
    /// Конструктор класса Lesson
    /// </summary>
    /// <param name="subject">Название предмета</param>
    /// <param name="teacher">Учитель</param>
    /// <param name="typeOfLesson">Тип пары</param>
    /// <param name="dateRange">Время начала и конца пары</param>
    public Lesson(Subject subject, Teacher teacher, TypeOfLesson? typeOfLesson, DateRange dateRange, Shedule shedule)
    {
        Subject = subject;
        Teacher = teacher;
        TypeOfLesson = typeOfLesson;
        DateRange = dateRange;
        Shedule = shedule;
        SheduleId = Shedule.Id;
        Validate();
    }

    /// <summary>
    /// Название предмета
    /// </summary>
    public Subject Subject { get; set; }
    /// <summary>
    /// Учитель
    /// </summary>
    public Teacher Teacher { get; set; }
    /// <summary>
    /// Тип пары
    /// </summary>
    public TypeOfLesson? TypeOfLesson  { get; set; }
    /// <summary>
    /// Время начала и конца пары
    /// </summary>
    public DateRange DateRange  { get; set; }
    
    public Shedule Shedule { get; set; }
    
    public Guid SheduleId { get; set; }
    
    /// <summary>
    /// Валидация экземпляра класса Lesson
    /// </summary>
    private void Validate()
    {
        var validate = new LessonValidator();
        validate.Validate(this);
    }

    /// <summary>
    /// Метод обновления класса Lesson
    /// </summary>
    /// <param name="lesson">Экземпляр класса Lesson</param>
    public void Update(Lesson lesson)
    {
        Subject = lesson.Subject;
        Teacher = lesson.Teacher;
        TypeOfLesson = lesson.TypeOfLesson;
        DateRange = lesson.DateRange;
    }
    
}