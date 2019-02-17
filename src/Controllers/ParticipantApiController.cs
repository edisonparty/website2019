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
        private IParticipantRepository participantRepository { get; }
		private IParticipantRealizer participantRealizer { get; }

        public ParticipantApiController(IParticipantRepository participantRepository, IParticipantRealizer participantRealizer)
        {
            this.participantRepository = participantRepository;
			this.participantRealizer = participantRealizer;
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
			try
			{
				participant = participantRealizer.RealizeParticipant(participant, ModelState);
			}
			catch (System.InvalidOperationException)
			{
                return BadRequest(ModelState);
			}

            return Created($"/api/Participant/{participant.RowKey}", participant);
        }
    }
}
