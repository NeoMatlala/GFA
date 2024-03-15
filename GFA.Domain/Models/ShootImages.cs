using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFA.Domain.Models
{
    public class ShootImages
    {
        public int ShootImagesId { get; set; }
        public int ShootId { get; set; }
        public int ImageId { get; set; }

        public Shoot Shoot { get; set; }
        public Image Image { get; set; }
    }
}
