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
    [Route("api/slack")]
    public class SlackInviteController : Controller
    {
        ISlackInviteRepository SlackInviteRepository { get; set; }
        public SlackInviteController(ISlackInviteRepository slackInviteRepository)
        {
            SlackInviteRepository = slackInviteRepository;
        }

        [HttpPost("invite")]
        [ProducesResponseType(typeof(void), 200)]
        public IActionResult InviteToSlack([FromBody] SlackInviteRequest slackInviteRequest)
        {
            var result = SlackInviteRepository.Invite(slackInviteRequest);
            if (result.Ok)
                return Ok();
          
            return BadRequest(result);
        }
    }
}