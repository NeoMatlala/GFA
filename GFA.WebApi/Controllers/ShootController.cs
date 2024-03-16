using GFA.Application.Services.ShootService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GFA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShootController : ControllerBase
    {
        private readonly IShootService _shootService;

        public ShootController(IShootService shootService)
        {
            _shootService = shootService;
        }

        //READ
        [HttpGet("get-shoots")]
        public IActionResult GetShoots()
        {
            var results = _shootService.GetShoots();

            return Ok(results);
        }

        [HttpGet("get-shoot/{id}")]
        public IActionResult GetShoot(int id)
        {
            var result = _shootService.GetShoot(id);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
