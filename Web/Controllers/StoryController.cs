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
    [Route("api/Story")]
    public class StoryController : Controller
    {
        IStoryRepository StoryRepository { get; set; }
        public StoryController(IStoryRepository storyRepository)
        {
            StoryRepository = storyRepository;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<Story>), 200)]
        public IActionResult GetParticipants()
        {
            var stories = StoryRepository.GetStories().GetAwaiter().GetResult();
            return Ok(stories);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Story), 200)]
        public IActionResult AddParticipant(string id)
        {
            var stories = StoryRepository.GetStories().GetAwaiter().GetResult();
            return NotFound();
        }
    }
}