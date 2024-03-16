using GFA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFA.Domain.DTOs
{
    public class ImagesShootDTO
    {
        public int ImageId { get; set; }
        //public Image Image { get; set; }
        public byte[]? ShootImage { get; set; }
    }
}
