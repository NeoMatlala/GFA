using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GFA.Domain.Models
{
    public class Image
    {
        public int ImageId { get; set; }

        [Column(TypeName = "Image")]
        public byte[]? ShootImage { get; set; }

        // navigation property
        //[JsonIgnore]
        //public List<ShootImages> ShootImages { get; set; }
    }
}
