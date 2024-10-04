using Gym.API.Core;
using Gym.API.DTO;
using Gym.Application.DTO.Gym;
using Gym.Application.UseCases.Queries;
using Gym.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gym.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenCreator _tokenCreator;
        private UseCaseHandler _useCaseHandler;

        public AuthController(JwtTokenCreator tokenCreator, UseCaseHandler commandHandler)
        {
            _tokenCreator = tokenCreator;
            _useCaseHandler = commandHandler;
        }
       
        [HttpGet]
        public IActionResult IsLogged([FromQuery] SearchGym dto, [FromServices] IIsLogged query)
       => Ok(_useCaseHandler.HandleQuery(query, dto));

        // POST api/<AuthController>
        [HttpPost]
        public IActionResult Post([FromBody] AuthRequest request)
        {
            string token = _tokenCreator.Create(request.Email, request.Password);

            return Ok(new AuthResponse { Token = token });
        }

        [Authorize]
        [HttpDelete]
        public IActionResult Delete([FromServices] ITokenStorage storage)
        {
            storage.Remove(this.Request.GetTokenId().Value);

            return NoContent();
        }
    }
}
