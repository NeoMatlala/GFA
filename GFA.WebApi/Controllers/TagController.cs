using GFA.Application.Services.TagService;
using GFA.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GFA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        // READ 
        [HttpGet("get-tags")]
        public IActionResult GetTags()
        {
            var tags = _tagService.GetTags();

            return Ok(tags);
        }

        // READ single tag
        [HttpGet("get-tag/{id}")]
        public IActionResult GetTag(int id)
        {
            if(id == 0 || id == null)
            {
                return BadRequest("Invalid ID");
            }

            var tag = _tagService.GetTag(id);

            if(tag == null)
            {
                return NotFound("Tag not found");
            }

            return Ok(tag);
        }

        // CREATE 
        [HttpPost("create-tag")]
        public IActionResult CreateTag([FromBody] Tag model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tag = _tagService.CreateTag(model);

            return Ok(tag);
        }

        // UPDATE
        [HttpPut("update-tag/{id}")]
        public IActionResult UpdateTag(int id, [FromBody] Tag model)
        {
            if (id == 0 || id == null)
            {
                return BadRequest("Invalid ID");
            }

            var result = _tagService.UpdateTag(id, model);

            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return Ok(result.Message);
        }

        // DELETE
        [HttpDelete("delete-tag/{id}")]
        public IActionResult DeleteTag(int id)
        {
            if (id == 0 || id == null)
            {
                return BadRequest("Invalid ID");
            }

            var result = _tagService.DeleteTag(id);

            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return Ok(new {isDeleted = true});
        }

    }
}
