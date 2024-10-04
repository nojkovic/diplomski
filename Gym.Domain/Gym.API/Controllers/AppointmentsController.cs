﻿using Gym.Application.DTO.Appointment;
using Gym.Application.DTO.Coach;
using Gym.Application.UseCases.Commands.Appointments;
using Gym.Application.UseCases.Commands.Coach;
using Gym.Application.UseCases.Queries;
using Gym.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gym.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public AppointmentsController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // GET: api/<AppointmentsController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchAppointment search, [FromServices] IGetAppointmentsQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }

        // GET api/<AppointmentsController>/5
        
        [HttpGet("{id}")]
        public IActionResult Find(int id, [FromServices] IGetAppointmentQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<AppointmentsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] AppointmentDTO dto, [FromServices] IAddAppointmentCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<AppointmentsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateAppointmentDTO dto,
                                                 [FromServices] IUpdateAppointmentCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<AppointmentsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteAppointmentCommand cmd, BaseAppointmentDTO dto)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }
    }
}
