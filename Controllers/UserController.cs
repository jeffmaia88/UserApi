using UserApi.Services;
using UserApi.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            try
            {
                var users = _userService.GetAllUsers();
                return Ok(new UserResult<List<UserResponse>>(users));


            }
            catch
            {
                return StatusCode(500, new UserResult<List<UserResponse>>("05X04 - Falha Interna no Servidor"));
            }


        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest(new UserResult<UserResponse>("05X02 - ID inválido"));

            try
            {
                var result = _userService.GetById(id);
                
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
        public IActionResult CreateUser([FromBody] UserRequest user )
        {
            var response = _userService.CreateUser(user);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateUser([FromRoute] int id, [FromBody] UserRequest user)
        {
            var response = _userService.UpdateUser(id, user);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            _userService.DeleteUser(id);
            return Ok();

        }

    }
}

