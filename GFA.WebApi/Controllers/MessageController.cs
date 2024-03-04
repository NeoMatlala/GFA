using GFA.Application.Services.ContactService;
using GFA.Application.Services.SocialService;
using GFA.Domain.DTOs;
using GFA.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GFA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IContactService _contactService;

        public MessageController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // READ
        [HttpGet("get-all-messages")]
        public IActionResult GetMessages()
        {
            var result = _contactService.GetMessages();

            return Ok(result);
        }

        [HttpGet("get-message/{id}")]
        public IActionResult GetMessage(int id)
        {
            if (id == 0 || id == null)
            {
                return BadRequest("Invalid ID");
            }

            var result = _contactService.GetMessage(id);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // CREATE
        [HttpPost("create-message")]
        public IActionResult CreateMessage([FromBody] MessageDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _contactService.CreateMessage(model);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
