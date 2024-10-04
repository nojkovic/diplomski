using Gym.Application.DTO.Contact;
using Gym.Application.UseCases.Commands.Contact;
using Gym.Application.UseCases.Commands.Contacts;
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
    public class ContactsController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public ContactsController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // GET: api/<ContactsController>
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] ContactSearch search, [FromServices] IGetContactsQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }

        // POST api/<ContactsController>
        [HttpPost]
        public IActionResult Post([FromBody] ContactDTO dto, [FromServices] IAddContactCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // DELETE api/<ContactsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteContactCommand cmd, BaseContactDTO dto)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }
    }
}
