using Gym.Application.DTO.Photo;
using Gym.Application.UseCases.Commands.Photos;
using Gym.Application.UseCases.Queries;
using Gym.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gym.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public PhotosController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // GET: api/<PhotoController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchPhoto search, [FromServices] IGetPhotosQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }

        // GET api/<PhotoController>/5
        
        [HttpGet("{id}")]
        public IActionResult Find(int id, [FromServices] IGetPhotoQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<PhotoController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] PhotoDTO dto,
                                  [FromServices] IAddPhotoCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        // PUT api/<PhotoController>/5
        [Authorize]
        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody] UpdatePhotoDTO dto, [FromServices] IUpdatePhotoCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<PhotoController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeletePhotoCommand cmd)
        {
            PhotoDTO dto = new PhotoDTO();
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }
    }
}
