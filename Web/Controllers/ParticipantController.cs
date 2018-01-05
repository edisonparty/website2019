using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Repositories;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Participant")]
    public class ParticipantController : Controller
    {
        const string partitionKey = "edisonparty2018";
        IParticipantRepository participantRepository { get; set; }
        public ParticipantController(IParticipantRepository participantRepository)
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

        [HttpPost("")]
        [ProducesResponseType(typeof(Participant), 201)]
        public IActionResult AddParticipant([FromBody]Participant participant)
        {
            participant.RowKey = Guid.NewGuid().ToString();
            participant.PartitionKey = partitionKey;
            participant.Registered = DateTime.UtcNow;

            if (participantRepository.GetParticipants(partitionKey).Any(p => p.Email == participant.Email))
                return new StatusCodeResult(StatusCodes.Status409Conflict);

            participantRepository.AddParticipant(participant);
            return Created($"/api/Participant/{participant.RowKey}",participant);
        }
    }
}