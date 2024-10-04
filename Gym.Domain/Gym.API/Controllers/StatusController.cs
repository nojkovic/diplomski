using Gym.Application.DTO.Location;
using Gym.Application.DTO.Status;
using Gym.Application.UseCases.Commands.Locations;
using Gym.Application.UseCases.Commands.Status;
using Gym.Application.UseCases.Queries;
using Gym.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gym.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public StatusController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // GET: api/<StatusController>
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] SearchStatus search, [FromServices] IGetStatusQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }

        // GET api/<StatusController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Find(int id, [FromServices] IGetStatusIdQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<StatusController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] StatusDTO dto, [FromServices] IAddStatusCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<StatusController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateStatusDTO dto,
                                                  [FromServices] IUpdateStatusCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<StatusController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteStatusCommand cmd, BaseStatusDTO dto)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }
    }
}
