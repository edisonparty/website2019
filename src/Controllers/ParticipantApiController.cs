using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Repositories;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Participant")]
    public class ParticipantApiController : Controller
    {
        private const string partitionKey = "edisonparty2019";
        IParticipantRepository participantRepository { get; }

        public ParticipantApiController(IParticipantRepository participantRepository)
        {
            this.participantRepository = participantRepository;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<Participant>), 200)]
        public IActionResult GetParticipants()
        {
            var participants = participantRepository.GetParticipants(partitionKey);

            return Ok(participants);
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(Participant), 201)]
        public IActionResult AddParticipant([FromBody]Participant participant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (participantRepository.GetParticipants(partitionKey).Any(p => p.Email == participant.Email))
            {
                ModelState.AddModelError("Email", "This e-mail address already exists");

                return BadRequest(ModelState);
            }

            participant.RowKey = Guid.NewGuid().ToString();
            participant.PartitionKey = partitionKey;
            participant.Registered = DateTime.UtcNow;

            participantRepository.AddParticipant(participant);

            return Created($"/api/Participant/{participant.RowKey}", participant);
        }
    }
}
