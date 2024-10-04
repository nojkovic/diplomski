using Gym.Application.DTO.Coach;
using Gym.Application.DTO.Location;
using Gym.Application.UseCases.Commands.Coach;
using Gym.Application.UseCases.Commands.Locations;
using Gym.Application.UseCases.Queries;
using Gym.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gym.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachsController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public CoachsController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // GET: api/<CoachsController>
       
        [HttpGet]
        public IActionResult Get([FromQuery] SearchCoach search, [FromServices] IGetCoachsQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }

        // GET api/<CoachsController>/5
        
        [HttpGet("{id}")]
        public IActionResult Find(int id, [FromServices] IGetCoachQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<CoachsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CoachDTO dto, [FromServices] IAddCoachCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<CoachsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCoachDTO dto,
                                                 [FromServices] IUpdateCoachCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<CoachsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCoachCommand cmd, BaseCoachDTO dto)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }
    }
}
