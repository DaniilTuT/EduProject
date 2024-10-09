using Domain.Primitives.Enums;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Lesson:BaseEntity
{
    public Subject Subject { get; set; }
    public Teacher Teacher { get; set; }
    public TypeOfLesson TypeOfLesson  { get; set; }
    public DateRange DateRange  { get; set; }

    public void Update(Lesson lesson)
    {
        Subject = lesson.Subject;
        Teacher = lesson.Teacher;
        TypeOfLesson = lesson.TypeOfLesson;
        DateRange = lesson.DateRange;
    }
    
}