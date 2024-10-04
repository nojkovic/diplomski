using Gym.Application.DTO.GroupTraining;
using Gym.Application.DTO.Location;
using Gym.Application.UseCases.Commands.GroupTrainings;
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
    public class LocationsController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public LocationsController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // GET: api/<LocationsController>
       
        [HttpGet]
        public IActionResult Get([FromQuery] SearchLocation search, [FromServices] IGetLocationsQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }

        // GET api/<LocationsController>/5
        
        [HttpGet("{id}")]
        public IActionResult Find(int id, [FromServices] IGetLocationQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<LocationsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] LocationDTO dto, [FromServices] IAddLocationCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<LocationsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateLocationDTO dto,
                                                  [FromServices] IUpdateLocationCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<LocationsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteLocationCommand cmd, BaseLocationDTO dto)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }
    }
}
