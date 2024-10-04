using Gym.Application.DTO.Appointment;
using Gym.Application.DTO.Gym;
using Gym.Application.UseCases.Commands.Appointments;
using Gym.Application.UseCases.Commands.Gyms;
using Gym.Application.UseCases.Queries;
using Gym.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gym.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymsController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public GymsController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // GET: api/<GymsController>
        
        [HttpGet]
        public IActionResult Get([FromQuery] SearchGym search, [FromServices] IGetGymsQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }

        // GET api/<GymsController>/5
       
        [HttpGet("{id}")]
        public IActionResult Find(int id, [FromServices] IGetGymQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<GymsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] GymDTO dto, [FromServices] IAddGymCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<GymsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateGymDTO dto,
                                                 [FromServices] IUpdateGymCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<GymsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteGymCommand cmd, BaseGymDTO dto)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }
    }
}
