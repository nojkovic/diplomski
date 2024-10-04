using Gym.Application.DTO.Coach;
using Gym.Application.DTO.Training;
using Gym.Application.UseCases.Commands.Coach;
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
    public class TrainingsController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public TrainingsController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // GET: api/<TrainingsController>
        
        [HttpGet]
        public IActionResult Get([FromQuery] SearchTraining search, [FromServices] IGetTrainingsQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }

        // GET api/<TrainingsController>/5
        
        [HttpGet("{id}")]
        public IActionResult Find(int id, [FromServices] IGetTrainingQuery query)
           => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<TrainingsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] TrainingDTO dto, [FromServices] IAddTrainingCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<TrainingsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateTrainingDTO dto,
                                                  [FromServices] IUpdateTrainingCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<TrainingsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteTrainingCommand cmd, BaseTrainingDTO dto)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }
    }
}
