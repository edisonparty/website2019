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
        IParticipantRepository participantRepository { get; set; }
        public ParticipantController(IParticipantRepository participantRepository)
        {
            this.participantRepository = participantRepository;
        }


        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<Participant>), 200)]
        public IActionResult GetParticipants()
        {
            var partitionKey = "2018";

            var participants = participantRepository.GetParticipants(partitionKey);
            return Ok(participants);
        }

        [HttpPost("")]
        [ProducesResponseType(typeof(Participant), 201)]
        public IActionResult AddParticipant([FromBody]Participant participant)
        {
            participant.RowKey = Guid.NewGuid().ToString();
            participant.PartitionKey = "2018";
            participant.Registered = DateTime.UtcNow;

            participantRepository.AddParticipant(participant);
            return Created($"/api/Participant/{participant.RowKey}",participant);
        }
    }
}