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
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserService _userService;
        private readonly IDistributedCache _cache;

        public UserController(IMapper mapper, UserService userService, IDistributedCache cache)
        {
            _mapper = mapper;
            _userService = userService;
            _cache = cache;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                string cacheKey = "AllUsers";
                var cachedData = await _cache.GetStringAsync(cacheKey);

                if (!string.IsNullOrEmpty(cachedData))
                {
                    var userDtos = JsonSerializer.Deserialize<IEnumerable<UserReadDto>>(cachedData);
                    return Ok(userDtos);
                }

                var users = _userService.GetAllUsers();
                var userDtosNew = _mapper.Map<IEnumerable<UserReadDto>>(users);

                var serializedData = JsonSerializer.Serialize(userDtosNew);
                var cacheOptions = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                };

                await _cache.SetStringAsync(cacheKey, serializedData, cacheOptions);
                return Ok(userDtosNew);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetUser([FromQuery] Guid id)
        {
            try
            {
                string cacheKey = $"User_{id}";
                var cachedData = await _cache.GetStringAsync(cacheKey);

                if (!string.IsNullOrEmpty(cachedData))
                {
                    var userDto = JsonSerializer.Deserialize<UserReadDto>(cachedData);
                    return Ok(userDto);
                }

                var user = _userService.GetUserById(id);
                if (user == null) return NotFound();

                var userDtoNew = _mapper.Map<UserReadDto>(user);

                var serializedData = JsonSerializer.Serialize(userDtoNew);
                var cacheOptions = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                };

                await _cache.SetStringAsync(cacheKey, serializedData, cacheOptions);
                return Ok(userDtoNew);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto request)
        {
            try
            {
                var user = _mapper.Map<User>(request);
                var createdUser = _userService.CreateUser(user);
                var userDto = _mapper.Map<UserReadDto>(createdUser);

                await _cache.RemoveAsync("AllUsers"); // Удаляем кэш всех пользователей
                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateDto request)
        {
            try
            {
                var existingUser = _userService.GetUserById(request.Id);
                if (existingUser == null) return NotFound();

                _mapper.Map(request, existingUser);
                var updatedUser = _userService.UpdateUser(existingUser);
                var userDto = _mapper.Map<UserReadDto>(updatedUser);

                await _cache.RemoveAsync("AllUsers");
                await _cache.RemoveAsync($"User_{request.Id}");
                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteUser([FromQuery] Guid id)
        {
            try
            {
                _userService.Delete(id);
                await _cache.RemoveAsync("AllUsers");
                await _cache.RemoveAsync($"User_{id}");
                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
