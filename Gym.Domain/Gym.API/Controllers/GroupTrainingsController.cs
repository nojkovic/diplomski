using Gym.Application.DTO.GroupTraining;
using Gym.Application.UseCases.Commands.GroupTrainings;
using Gym.Application.UseCases.Commands.MembershipFees;
using Gym.Application.UseCases.Queries;
using Gym.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gym.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupTrainingsController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public GroupTrainingsController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // GET: api/<GroupTrainingsController>
       
        [HttpGet]
        public IActionResult Get([FromQuery] SearchGroupTraining search, [FromServices] IGetGroupTrainingsQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }

        // GET api/<GroupTrainingsController>/5
       
        [HttpGet("{id}")]
        public IActionResult Find(int id, [FromServices] IGetGroupTrainingQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<GroupTrainingsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] GroupTrainingDTO dto, [FromServices] IAddGroupTrainingCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<GroupTrainingsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateGroupTrainingDTO dto,
                                                  [FromServices] IUpdateGroupTrainingCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<GroupTrainingsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteGroupTrainingCommand cmd, BaseGroupTrainingDTO dto)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }
    }
}
