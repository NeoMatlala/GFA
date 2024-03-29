﻿using GFA.Application.Services.ShootService;
using GFA.Domain.DTOs;
using GFA.Domain.Models;
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

        // Create shoot
        [HttpPost("create-shoot")]
        public IActionResult CreateShoot([FromForm] Shoot model, IFormFile? mainImage, List<IFormFile>? shootImages)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _shootService.CreateShoot(model, mainImage, shootImages);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // UPDATE
        [HttpPut("update-shoot/{id}")]
        public IActionResult UpdateShoot(int id, [FromForm] UpdateShootDTO model, IFormFile? mainImage, List<IFormFile>? shootImages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _shootService.UpdateShoot(id, model, mainImage, shootImages);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // DELETE
        [HttpDelete("delete-shoot/{id}")]
        public IActionResult DeleteShoot(int id)
        {
            var result = _shootService.DeleteShoot(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
