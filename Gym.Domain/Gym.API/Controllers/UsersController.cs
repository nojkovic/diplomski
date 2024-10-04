using Gym.Application.DTO.User;
using Gym.Application.UseCases.Commands.Users;
using Gym.Application.UseCases.Queries;
using Gym.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gym.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public UsersController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] RegisterUserDTO dto, [FromServices] IRegisterUserCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand cmd, BaseUserDto dto)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }

       
        [HttpGet("{id}")]
        public IActionResult Find(int id, [FromServices] IGetUserQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, id));

        [HttpGet]
        public IActionResult Get([FromQuery] UserSearch search, [FromServices] IGetUsersQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UserModify(int id, [FromBody] UpdateUserDto dto,
                                                  [FromServices] IUpdateUserCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        [Authorize]
        [HttpPatch("{id}")]
        public IActionResult ModifyAccess(int id, [FromBody] UserUpdatePatch dto,
                                                  [FromServices] IModifyAccessCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }


    }
}
