using Gym.Application.DTO.Coach;
using Gym.Application.DTO.Reservation;
using Gym.Application.DTO.User;
using Gym.Application.UseCases.Commands.Coach;
using Gym.Application.UseCases.Commands.Reservations;
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
    public class ReservationsController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public ReservationsController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // GET: api/<ReservationsController>
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] SearchReservation search, [FromServices] IGetReservationsQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }

        // GET api/<ReservationsController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Find(int id, [FromServices] IGetReservationQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<ReservationsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] ReservationDTO dto, [FromServices] IAddReservationCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<ReservationsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateReservationDTO dto,
                                                 [FromServices] IUpdateReservationCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }
        [Authorize]
        [HttpPatch("{id}")]
        public IActionResult ModifyStatus(int id, [FromBody] ReservationUpdatePatch dto,
                                                  [FromServices] IModifyStatusCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }
        // DELETE api/<ReservationsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteReservationCommand cmd)
        {
            BaseReservationDTO dto = new BaseReservationDTO();
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }
    }
}
