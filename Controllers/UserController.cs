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
            var users = _userService.GetAllUsers();
            return Ok(users);

        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
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

