using GFA.Application.Services.TagService;
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
    }
}
