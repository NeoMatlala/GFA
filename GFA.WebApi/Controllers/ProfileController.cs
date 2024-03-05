using GFA.Application.Services.ProfileService;
using GFA.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GFA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        // READ
        [HttpGet("get-profile")]
        public IActionResult GetProfile()
        {
            var result = _profileService.GetProfiles();

            return Ok(result);
        }

        // CREATE
        //[HttpPost("create-profile")]
        //public IActionResult CreateProfile([FromForm] Profile model, IFormFile image)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var result = _profileService.CreateProfile(model, image);

        //    if (!result.Success)
        //    {
        //        return BadRequest(result);
        //    }

        //    return Ok(result);
        //}

        // UPDATE
        [HttpPut("update-profile/{id}")]
        public IActionResult UpdateProfile(int id, [FromForm] Profile model, IFormFile? image)
        {
            if(id == 0 || id == null)
            {
                return BadRequest("Invalid ID");
            }

            var result = _profileService.UpdateProfile(id, model, image);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
