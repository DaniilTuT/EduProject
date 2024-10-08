using System.Reflection.PortableExecutable;
using Application.Exceptions;
using Application.Interfaces.Repository;
using Domain.Entities;

namespace Application.Services;


public class LessonService
{
    private readonly ILessonRepository _lessonRepository;

    public LessonService(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }


    public Lesson GetLessonById(Guid lessonId)
    {
        var lesson = GetByIdOrThrow(lessonId);
        return lesson;
    }

    public List<Lesson> GetAllLessons()
    {
        var lessons = _lessonRepository.GetAll();
        return lessons;
    }

    public Lesson CreateLesson(Lesson lesson)
    {
        _lessonRepository.Create(lesson);
        return lesson;
    }
    
    
    public Lesson UpdateLesson(Lesson lesson)
    {
        var less = GetByIdOrThrow(lesson.Id);
        less.Update(lesson);
        _lessonRepository.Update(less);
        return lesson;
    }
    
    
    private Lesson GetByIdOrThrow(Guid id)
    {
        var lesson = _lessonRepository.GetById(id);
        if (lesson == null)
        {
            throw new EntityNotFoundException<Lesson>(nameof(Lesson.Id), id.ToString());
        }

        return lesson;
    }
}