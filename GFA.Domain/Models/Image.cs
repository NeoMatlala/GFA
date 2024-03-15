using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFA.Domain.Models
{
    public class Image
    {
        public int ImageId { get; set; }

        [Column(TypeName = "Image")]
        public byte[]? ShootImage { get; set; }

        // navigation property
        public ICollection<ShootImages> ShootImages { get; set; }
    }
}
