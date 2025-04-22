using System.Text.Json;
using Application.Dtos.LessonDtos;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Infrastructure.Api;

[ApiController]
[Route("api/[controller]")]
public class LessonController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly LessonService _lessonService;
    private readonly IDistributedCache _cache;

    public LessonController(IMapper mapper, LessonService lessonService, IDistributedCache cache)
    {
        _mapper = mapper;
        _lessonService = lessonService;
        _cache = cache;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllLessons()
    {
        string cacheKey = "all_lessons";
        var cachedData = await _cache.GetStringAsync(cacheKey);

        if (cachedData != null)
        {
            var cachedLessons = JsonSerializer.Deserialize<IEnumerable<LessonReadDto>>(cachedData);
            return Ok(cachedLessons);
        }

        try
        {
            var lessons = _lessonService.GetAllLessons();
            var lessonDtos = _mapper.Map<IEnumerable<LessonReadDto>>(lessons);

            var serializedData = JsonSerializer.Serialize(lessonDtos);
            await _cache.SetStringAsync(cacheKey, serializedData, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            });

            return Ok(lessonDtos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> GetLesson([FromQuery] Guid id)
    {
        string cacheKey = $"lesson_{id}";
        var cachedData = await _cache.GetStringAsync(cacheKey);

        if (cachedData != null)
        {
            var cachedLesson = JsonSerializer.Deserialize<LessonReadDto>(cachedData);
            return Ok(cachedLesson);
        }

        try
        {
            var lesson = _lessonService.GetLessonById(id);
            if (lesson == null) return NotFound();

            var lessonDto = _mapper.Map<LessonReadDto>(lesson);
            var serializedData = JsonSerializer.Serialize(lessonDto);
            await _cache.SetStringAsync(cacheKey, serializedData, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            });

            return Ok(lessonDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpPost("Create")]
    public async Task<IActionResult> CreateLesson([FromBody] LessonCreateDto request)
    {
        try
        {
            var lesson = _mapper.Map<Lesson>(request);
            var createdLesson = _lessonService.CreateLesson(lesson);
            var lessonDto = _mapper.Map<LessonReadDto>(createdLesson);

            await _cache.RemoveAsync("all_lessons");

            return Ok(lessonDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpPut("Update")]
    public async Task<IActionResult> UpdateLesson([FromBody] LessonUpdateDto request)
    {
        try
        {
            var existingLesson = _lessonService.GetLessonById(request.Id);
            if (existingLesson == null) return NotFound();

            _mapper.Map(request, existingLesson);
            var updatedLesson = _lessonService.UpdateLesson(existingLesson);
            var lessonDto = _mapper.Map<LessonReadDto>(updatedLesson);

            string cacheKey = $"lesson_{request.Id}";
            await _cache.RemoveAsync(cacheKey);
            await _cache.RemoveAsync("all_lessons");

            return Ok(lessonDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteLesson([FromQuery] Guid id)
    {
        try
        {
            _lessonService.Delete(id);

            string cacheKey = $"lesson_{id}";
            await _cache.RemoveAsync(cacheKey);
            await _cache.RemoveAsync("all_lessons");

            return Ok(true);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
