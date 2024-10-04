using Gym.Application.DTO.Rating;
using Gym.Application.UseCases.Commands.Ratings;
using Gym.Application.UseCases.Queries;
using Gym.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gym.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public RatingsController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // GET: api/<RatingsController>
        [HttpGet]
        public IActionResult Find([FromQuery] SearchRatingDTO dto, [FromServices] IGetRatingsQuery query)
           => Ok(_useCaseHandler.HandleQuery(query, dto));

        // GET api/<RatingsController>/5
        [HttpGet("{id}")]
        public IActionResult Find(int id, [FromServices] IGetRatingQuery query)
           => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<RatingsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] RatingDTO dto, [FromServices] IAddRatingCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<RatingsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateRatingDTO dto, [FromServices] IUpdateRatingCommand cmd)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return NoContent();
        }

        // DELETE api/<RatingsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteRatingCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, id);
            return NoContent();
        }
    }
}
