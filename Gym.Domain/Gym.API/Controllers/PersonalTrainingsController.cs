using Gym.Application.DTO.PersonalTraining;
using Gym.Application.UseCases.Commands.GroupTrainings;
using Gym.Application.UseCases.Commands.PersonalTrainings;
using Gym.Application.UseCases.Queries;
using Gym.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gym.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalTrainingsController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public PersonalTrainingsController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // GET: api/<PersonalTrainingsController>
       
        [HttpGet]
        public IActionResult Get([FromQuery] SearchPersonalTraining search, [FromServices] IGetPersonalTrainingsQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }

        // GET api/<PersonalTrainingsController>/5
        
        [HttpGet("{id}")]
        public IActionResult Find(int id, [FromServices] IGetPersonalTrainingQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, id));


        // POST api/<PersonalTrainingsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] PersonalTrainingDTO dto, [FromServices] IAddPersonalTrainingCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<PersonalTrainingsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdatePersonalTrainingDTO dto,
                                                  [FromServices] IUpdatePersonalTraining command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<PersonalTrainingsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeletePersonalTrainingCommand cmd, BasePersonalTrainingDTO dto)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }
    }
}
