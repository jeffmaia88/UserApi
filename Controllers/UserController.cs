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
            if(!ModelState.IsValid)
                return BadRequest( new UserResult<UserResponse>(ModelState.GetErrors()));

            try
            {
                var response = _userService.CreateUser(user);
                return Ok(new UserResult<UserResponse>(response.Data));
            }
            catch
            {
                return StatusCode(500, new UserResult<UserResponse>("05X04 - Falha Interna no Servidor"));
            }
            
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateUser([FromRoute] int id, [FromBody] UserRequest user)
        {
            if (id <= 0)
                return BadRequest(new UserResult<UserResponse>("05X02 - ID inválido"));

            if (!ModelState.IsValid)
                return BadRequest(new UserResult<UserResponse>(ModelState.GetErrors()));
            try
            {
                var response = _userService.UpdateUser(id, user);
                return Ok(response);
            }
            catch
            {
                return StatusCode(500, new UserResult<UserResponse>("05X04 - Falha Interna no Servidor"));
            }
            
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            if (id<= 0)
                return BadRequest(new UserResult<UserResponse>("05X02 - ID inválido"));

            try
            {
                var response = _userService.DeleteUser(id);

                return Ok(response);
            }
            catch
            {
                return StatusCode(500, new UserResult<UserResponse>("05X04 - Falha Interna no Servidor"));
            }            

        }

    }
}

