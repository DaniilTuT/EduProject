using Domain.Primitives.Enums;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Lesson:BaseEntity
{
    
    Subject Subject { get; set; }
    Teacher Teacher { get; set; }
    TypeOfLesson TypeOfLesson  { get; set; }
    DateRange DateRange  { get; set; }

    public void Update(Lesson lesson)
    {
        Subject = lesson.Subject;
        Teacher = lesson.Teacher;
        TypeOfLesson = lesson.TypeOfLesson;
        DateRange = lesson.DateRange;
    }
    
}