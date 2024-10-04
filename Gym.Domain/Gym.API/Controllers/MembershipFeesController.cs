using System.Reflection.Metadata;
using Gym.Application.DTO.MembershipFee;
using Gym.Application.UseCases.Commands.Contact;
using Gym.Application.UseCases.Commands.MembershipFees;
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
    public class MembershipFeesController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public MembershipFeesController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // GET: api/<MembershipFeesController>
        
        [HttpGet]
        public IActionResult Get([FromQuery] SearchMembershipFee search, [FromServices] IGetMembershipFeesQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }

        // GET api/<MembershipFeesController>/5
        
        [HttpGet("{id}")]
        public IActionResult Find(int id, [FromServices] IGetMembershipFeeQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<MembershipFeesController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] MembershipFeeDTO dto, [FromServices] IAddMembershipFeeCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<MembershipFeesController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateMembershipFeeDTO dto,
                                                  [FromServices] IUpdateMembershipFeeCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<MembershipFeesController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteMembershipFeeCommand cmd, BaseMembershipFeeDTO dto)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }
    }
}
