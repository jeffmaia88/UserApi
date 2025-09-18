
using UserApi.Services;
using UserApi.Models;
using Microsoft.AspNetCore.Mvc;
using UserApi.Extensions;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 0, [FromQuery] int pageSize = 10)
        {
            try
            {
                var allUsers = await _userService.GetAllUsers();
                var pagedUsers = allUsers
                    .OrderBy(x => x.Nome)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();

                return Ok(new UserResult<List<UserResponse>>(pagedUsers));
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
                return Ok(response);
            }
            catch
            {
                return StatusCode(500, new UserResult<UserResponse>("05X04 - Falha Interna no Servidor"));
            }
        }
    }
}