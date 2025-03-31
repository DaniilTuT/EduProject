using Application.Dtos;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;


namespace Infrastructure.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class SheduleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly SheduleService _sheduleService;
        private readonly IDistributedCache _cache;

        public SheduleController(IMapper mapper, IDistributedCache cache,SheduleService sheduleService)
        {
            _mapper = mapper;
            _cache = cache;
            _sheduleService = sheduleService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllShedule()
        {
            string cacheKey = "all_shedules";
            string cachedData = await _cache.GetStringAsync(cacheKey);

            if (cachedData != null)
            {
                var cachedShedules = JsonSerializer.Deserialize<IEnumerable<SheduleReadDto>>(cachedData);
                return Ok(cachedShedules);
            }

            try
            {
                var shedules = _sheduleService.GetAllShedules();
                var sheduleDtos = _mapper.Map<IEnumerable<SheduleReadDto>>(shedules);

                var serializedData = JsonSerializer.Serialize(sheduleDtos);
                await _cache.SetStringAsync(cacheKey, serializedData, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                });

                return Ok(sheduleDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetShedule([FromQuery] Guid id)
        {
            string cacheKey = $"shedule_{id}";
            string cachedData = await _cache.GetStringAsync(cacheKey);

            if (cachedData != null)
            {
                var cachedShedule = JsonSerializer.Deserialize<SheduleReadDto>(cachedData);
                return Ok(cachedShedule);
            }

            try
            {
                var shedule = _sheduleService.GetSheduleById(id);
                if (shedule == null) return NotFound();

                var sheduleDto = _mapper.Map<SheduleReadDto>(shedule);
                var serializedData = JsonSerializer.Serialize(sheduleDto);
                await _cache.SetStringAsync(cacheKey, serializedData, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                });

                return Ok(sheduleDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateShedule([FromBody] SheduleCreateDto request)
        {
            try
            {
                var shedule = _mapper.Map<Shedule>(request);
                var createdShedule = _sheduleService.CreateShedule(shedule);
                var sheduleDto = _mapper.Map<SheduleReadDto>(createdShedule);

                await _cache.RemoveAsync("all_shedules"); // Чистим кеш всех расписаний

                return Ok(sheduleDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateShedule([FromBody] SheduleUpdateDto request)
        {
            try
            {
                var existingShedule = _sheduleService.GetSheduleById(request.Id);
                if (existingShedule == null) return NotFound();

                _mapper.Map(request, existingShedule);
                var updatedShedule = _sheduleService.UpdateShedule(existingShedule);
                var sheduleDto = _mapper.Map<SheduleReadDto>(updatedShedule);

                string cacheKey = $"shedule_{request.Id}";
                await _cache.RemoveAsync(cacheKey);
                await _cache.RemoveAsync("all_shedules"); // Чистим кеш всех расписаний

                return Ok(sheduleDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteShedule([FromQuery] Guid id)
        {
            try
            {
                _sheduleService.Delete(id);

                string cacheKey = $"shedule_{id}";
                await _cache.RemoveAsync(cacheKey);
                await _cache.RemoveAsync("all_shedules"); // Чистим кеш всех расписаний

                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
