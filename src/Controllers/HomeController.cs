using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Web.Models;
using Web.Repositories;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private const string partitionKey = "edisonparty2019";
		private IParticipantRepository participantRepository { get; }
		private IParticipantRealizer participantRealizer { get; }

		public HomeController(IParticipantRepository participantRepository, IParticipantRealizer participantRealizer)
		{
			this.participantRepository = participantRepository;
			this.participantRealizer = participantRealizer;
		}

        public IActionResult Index()
        {
			var participants = participantRepository.GetParticipants(partitionKey);
			
            return View(participants);
        }

        [HttpPost]
        public IActionResult Register([FromForm]Participant participant)
		{
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			try
			{
				participantRealizer.RealizeParticipant(participant, participantRepository);
			}
			catch (System.InvalidOperationException)
			{
				ModelState.AddModelError("Email", "This e-mail address already exists");
                return BadRequest(ModelState);
			}

			return Redirect("/#visitors");
		}

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
