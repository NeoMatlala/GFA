using GFA.Domain.DTOs;
using GFA.Domain.Models;
using GFA.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFA.Application.Services.ShootService
{
    public class ShootService : IShootService
    {
        private readonly ApplicationDbContext _db;

        public ShootService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<ShootImagesDTO> GetShoots()
        {
            var shoots = _db.Shoots.Include(s => s.ShootImages).ThenInclude(i => i.Image).ToList();

            var shootsDTO = shoots.Select(s => new ShootImagesDTO
            {
                ShootId = s.ShootId,
                Name = s.Name,
                Client = s.Client,
                Category = s.Category,
                Description = s.Description,
                MainImage = s.MainImage,
                ShootImages = s.ShootImages.Select(i => new ImagesShootDTO
                {
                    ImageId = i.ImageId,
                    ShootImage = i.Image.ShootImage
                }).ToList()
            }).ToList();
            
            return shootsDTO;
        }

        public ShootResponse GetShoot(int id)
        {
            if(id == 0 || id == null)
            {
                return new ShootResponse
                {
                    Success = false,
                    Message = "Invalid ID"
                };
            }

            var shoot = _db.Shoots.Include(s => s.ShootImages).ThenInclude(i => i.Image).FirstOrDefault(s => s.ShootId == id);

            if (shoot == null)
            {
                return new ShootResponse
                {
                    Success = false,
                    Message = "Shoot does not exist!"
                };
            }

            var shootsDTO = new ShootImagesDTO
            {
                ShootId = shoot.ShootId,
                Name = shoot.Name,
                Client = shoot.Client,
                Category = shoot.Category,
                Description = shoot.Description,
                MainImage = shoot.MainImage,
                ShootImages = shoot.ShootImages.Select(i => new ImagesShootDTO
                {
                    ImageId = i.ImageId,
                    ShootImage = i.Image.ShootImage
                }).ToList()
            };

            return new ShootResponse
            {
                Success = true,
                Message = "Shoot found",
                shootObj = shootsDTO
            };
        }
    }
}
