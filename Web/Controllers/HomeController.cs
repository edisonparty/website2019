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

		public HomeController(IParticipantRepository participantRepository)
		{
			this.participantRepository = participantRepository;
		}

        public IActionResult Index()
        {
            return View(participantRepository.GetParticipants(partitionKey));
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
