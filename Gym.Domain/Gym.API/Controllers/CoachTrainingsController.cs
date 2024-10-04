using Gym.Application.DTO.Coach;
using Gym.Application.DTO.CoachTraining;
using Gym.Application.DTO.Training;
using Gym.Application.UseCases.Commands.Coach;
using Gym.Application.UseCases.Commands.CoachTrainings;
using Gym.Application.UseCases.Commands.Trainings;
using Gym.Application.UseCases.Queries;
using Gym.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gym.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachTrainingsController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public CoachTrainingsController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // GET: api/<CoachTrainingsController>
       
        [HttpGet]
        public IActionResult Get([FromQuery] SearchCoachTraining search, [FromServices] IGetCoachTrainingsQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }

        // GET api/<CoachTrainingsController>/5
       
        [HttpGet("{id}")]
        public IActionResult Find(int id, [FromServices] IGetCoachTrainingQuery query)
           => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<CoachTrainingsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CoachTrainingDTO dto, [FromServices] IAddCoachTrainingCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<CoachTrainingsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCoachTrainingDTO dto,
                                                 [FromServices] IUpdateCoachTrainingCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<CoachTrainingsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCoachTrainingCommand cmd, BaseCoachTrainingDTO dto)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }
    }
}
