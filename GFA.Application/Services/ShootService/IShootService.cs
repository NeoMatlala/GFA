using GFA.Domain.DTOs;
using GFA.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFA.Application.Services.ShootService
{
    public interface IShootService
    {
        List<ShootImagesDTO> GetShoots();

        ShootResponse GetShoot(int id);

        ShootResponse DeleteShoot(int id);

        ShootResponse CreateShoot(Shoot model, IFormFile? mainImage, List<IFormFile>? shootImages);
    }
}
