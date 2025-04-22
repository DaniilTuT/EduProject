using System.Text.Json;
using Application.Dtos.GroupDtos;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Infrastructure.Api;

[ApiController]
[Route("api/[controller]")]
public class GroupController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly GroupService _groupService;
    private readonly IDistributedCache _cache;
    
    public GroupController(IMapper mapper, GroupService groupService, IDistributedCache cache)
    {
        _mapper = mapper;
        _groupService = groupService;
        _cache = cache;
    }
    
     [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllGroups()
    {
        // string cacheKey = "all_groups";
        // var cachedData = await _cache.GetStringAsync(cacheKey);
        //
        // if (cachedData != null)
        // {
        //     var cachedGroups = JsonSerializer.Deserialize<IEnumerable<GroupReadDto>>(cachedData);
        //     return Ok(cachedGroups);
        // }

        try
        {
            var group = _groupService.GetAllGroups();
            var groupDtos = _mapper.Map<IEnumerable<GroupReadDto>>(group);

            // var serializedData = JsonSerializer.Serialize(groupDtos);
            // await _cache.SetStringAsync(cacheKey, serializedData, new DistributedCacheEntryOptions
            // {
            //     AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            // });

            return Ok(groupDtos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("Get")]
    public async Task<IActionResult> GetGroup([FromQuery] Guid id)
    {
        // string cacheKey = $"group_{id}";
        // var cachedData = await _cache.GetStringAsync(cacheKey);
        //
        // if (cachedData != null)
        // {
        //     var cachedLesson = JsonSerializer.Deserialize<GroupReadDto>(cachedData);
        //     return Ok(cachedLesson);
        // }

        try
        {
            var group = _groupService.GetGroupById(id);
            if (group == null) return NotFound();

            var groupDto = _mapper.Map<GroupReadDto>(group);
            // var serializedData = JsonSerializer.Serialize(groupDto);
            // await _cache.SetStringAsync(cacheKey, serializedData, new DistributedCacheEntryOptions
            // {
            //     AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            // });

            return Ok(groupDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpPost("Create")]
    public async Task<IActionResult> CreateGroup([FromBody] GroupCreateDto request)
    {
        try
        {
            var group = _mapper.Map<Group>(request);
            var createdGroup = _groupService.CreateGroup(group);
            var groupDto = _mapper.Map<GroupReadDto>(createdGroup);

            // await _cache.RemoveAsync("all_groups");

            return Ok(groupDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpPut("Update")]
    public async Task<IActionResult> UpdateGroup([FromBody] GroupUpdateDto request)
    {
        try
        {
            var existingGroup = _groupService.GetGroupById(request.Id);
            if (existingGroup == null) return NotFound();

            _mapper.Map(request, existingGroup);
            var updatedGroup = _groupService.UpdateGroup(existingGroup);
            var groupDto = _mapper.Map<GroupReadDto>(updatedGroup);

            // string cacheKey = $"group_{request.Id}";
            // await _cache.RemoveAsync(cacheKey);
            // await _cache.RemoveAsync("all_groups");

            return Ok(groupDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteGroup([FromQuery] Guid id)
    {
        try
        {
            _groupService.Delete(id);

            // string cacheKey = $"group_{id}";
            // await _cache.RemoveAsync(cacheKey);
            // await _cache.RemoveAsync("all_groups");

            return Ok(true);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
