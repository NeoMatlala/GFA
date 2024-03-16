using GFA.Domain.DTOs;
using GFA.Domain.Models;
using GFA.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
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

        public ShootResponse CreateShoot(Shoot model, IFormFile? mainImage, List<IFormFile>? shootImages)
        {
            try
            {
                // Shoot table image = main image
                var shoot = new Shoot
                {
                    Name = model.Name,
                    Client = model.Client,
                    Category = model.Category,
                    Description = model.Description
                };

                using (MemoryStream stream = new MemoryStream())
                {
                    mainImage.CopyTo(stream);

                    shoot.MainImage = stream.ToArray();

                    var mainImageEntity = new Image
                    {
                        ShootImage = stream.ToArray()
                    };

                    _db.Images.Add(mainImageEntity);
                    _db.SaveChanges();
                }

                _db.Shoots.Add(shoot);
                _db.SaveChanges();

                // shoot images
                if (shootImages != null && shootImages.Any())
                {
                    foreach(var imageFile in shootImages)
                    {
                        using (MemoryStream stream = new MemoryStream())
                        {
                            imageFile.CopyTo(stream);

                            var imageEntity = new Image
                            {
                                ShootImage = stream.ToArray()
                            };

                            _db.Images.Add(imageEntity);
                            _db.SaveChanges();

                            var shootImage = new ShootImages
                            {
                                ShootId = shoot.ShootId,
                                ImageId = imageEntity.ImageId
                            };

                            _db.ShootImages.Add(shootImage);
                        }
                    }

                    _db.SaveChanges();
                }

                // image in images Table
                //var images = new Image
                //{
                //    ShootImage = shoot.MainImage
                //};

                //_db.Images.Add(images);
                //_db.SaveChanges();

                // image in shootImages
                //var shootImages = new ShootImages
                //{
                //    ShootId = shoot.ShootId,
                //    ImageId = images.ImageId
                //};

                //_db.ShootImages.Add(shootImages);
                //_db.SaveChanges();

                return new ShootResponse
                {
                    Success = true,
                    Message = "Shoot successfully created"
                };
            }
            catch (Exception ex)
            {
                return new ShootResponse
                {
                    Success = false,
                    Message = $"Error creating shoot: {ex}"
                };
            }
            
        }
    }
}
