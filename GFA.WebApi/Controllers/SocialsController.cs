using GFA.Application.Services.SocialService;
using GFA.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GFA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialsController : ControllerBase
    {
        private readonly ISocialsService _socialsService;

        public SocialsController(ISocialsService socialsService)
        {
            _socialsService = socialsService;
        }

        // READ
        [HttpGet("get-all-links")]
        public IActionResult GetLinks()
        {
            var links = _socialsService.GetLinks();

            return Ok(links);
        }

        [HttpGet("get-link/{id}")]
        public IActionResult GetLink(int id)
        {
            if(id == 0 || id == null)
            {
                return BadRequest("Invalid ID");
            }

            var result = _socialsService.GetLink(id);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result.Link);
        }

        // CREATE
        [HttpPost("create-social-link")]
        public IActionResult CreateLink([FromBody] Social model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _socialsService.CreateLink(model);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        // UPDATE
        [HttpPut("update-link/{id}")]
        public IActionResult UpdateSocialLink(int id, [FromBody] Social model)
        {
            if (id == 0 || id == null)
            {
                return BadRequest("Invalid ID");
            }

            var result = _socialsService.UpdateLink(id, model);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // DELETE
        [HttpDelete("delete-link/{id}")]
        public IActionResult DeleteLink(int id)
        {
            if (id == 0 || id == null)
            {
                return BadRequest("Invalid ID");
            }

            var result = _socialsService.DeleteLink(id);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
