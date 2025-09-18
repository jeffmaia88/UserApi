using UserApi.Services;
using UserApi.Models;
using Microsoft.AspNetCore.Mvc;
using UserApi.Extensions;
using Microsoft.Extensions.Caching.Memory;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IMemoryCache _memoryCache;

        
        private static readonly List<string> _userCacheKeys = new();

        public UserController(UserService userService, IMemoryCache memoryCache)
        {
            _userService = userService;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 0, [FromQuery] int pageSize = 10)
        {
            var cacheKey = $"users_page_{page}_size_{pageSize}";

            
            if (!_userCacheKeys.Contains(cacheKey))
                _userCacheKeys.Add(cacheKey);

            try
            {
                var users = await _memoryCache.GetOrCreateAsync(cacheKey, async entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);

                    var allUsers = await _userService.GetAllUsers();
                    return allUsers.OrderBy(x => x.Nome).Skip(page * pageSize).Take(pageSize).ToList();
                });

                return Ok(new UserResult<List<UserResponse>>(users));
            }
            catch
            {
                return StatusCode(500, new UserResult<List<UserResponse>>("05X04 - Falha Interna no Servidor"));
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest(new UserResult<UserResponse>("05X02 - ID inválido"));

            try
            {
                var result = await _userService.GetById(id);

                if (result.Data == null)
                    return NotFound(result);

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, new UserResult<UserResponse>("05X04 - Falha Interna no Servidor"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserRequest user)
        {
            if (!ModelState.IsValid)
                return BadRequest(new UserResult<UserResponse>(ModelState.GetErrors()));

            try
            {
                var response = await _userService.CreateUser(user);

                
                foreach (var key in _userCacheKeys)
                    _memoryCache.Remove(key);
                _userCacheKeys.Clear();

                return Ok(new UserResult<UserResponse>(response.Data));
            }
            catch
            {
                return StatusCode(500, new UserResult<UserResponse>("05X04 - Falha Interna no Servidor"));
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UserRequest user)
        {
            if (id <= 0)
                return BadRequest(new UserResult<UserResponse>("05X02 - ID inválido"));

            if (!ModelState.IsValid)
                return BadRequest(new UserResult<UserResponse>(ModelState.GetErrors()));

            try
            {
                var response = await _userService.UpdateUser(id, user);

                
                foreach (var key in _userCacheKeys)
                    _memoryCache.Remove(key);
                _userCacheKeys.Clear();

                return Ok(response);
            }
            catch
            {
                return StatusCode(500, new UserResult<UserResponse>("05X04 - Falha Interna no Servidor"));
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest(new UserResult<UserResponse>("05X02 - ID inválido"));

            try
            {
                var response = await _userService.DeleteUser(id);

                
                foreach (var key in _userCacheKeys)
                    _memoryCache.Remove(key);
                _userCacheKeys.Clear();

                return Ok(response);
            }
            catch
            {
                return StatusCode(500, new UserResult<UserResponse>("05X04 - Falha Interna no Servidor"));
            }
        }
    }
}