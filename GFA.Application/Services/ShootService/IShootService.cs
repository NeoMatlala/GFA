using GFA.Domain.DTOs;
using GFA.Domain.Models;
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
    }
}
