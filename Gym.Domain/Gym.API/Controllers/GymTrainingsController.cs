using Gym.Application.DTO.CoachTraining;
using Gym.Application.DTO.GymTraining;
using Gym.Application.UseCases.Commands.CoachTrainings;
using Gym.Application.UseCases.Commands.GymTraining;
using Gym.Application.UseCases.Queries;
using Gym.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gym.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymTrainingsController : ControllerBase
    {
        // GET: api/<GymTrainingsController>
        private UseCaseHandler _useCaseHandler;

        public GymTrainingsController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // GET: api/<GymTrainingsController>

        [HttpGet]
        public IActionResult Get([FromQuery] SearchGymTraining search, [FromServices] IGetGymTrainingsQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }

        // GET api/<GymTrainingsController>/5

        [HttpGet("{id}")]
        public IActionResult Find(int id, [FromServices] IGetGymTrainingQuery query)
           => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<CoachTrainingsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] GymTrainingDTO dto, [FromServices] IAddGymTrainingCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<GymTrainingsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateGymTrainingDTO dto,
                                                 [FromServices] IUpdateGymTrainingCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<GymTrainingsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteGymTrainingCommand cmd, BaseGymTrainingDTO dto)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }
    }
}
