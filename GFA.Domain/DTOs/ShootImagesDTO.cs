using GFA.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFA.Domain.DTOs
{
    public class ShootImagesDTO
    {
        public int ShootId { get; set; }
        public string Name { get; set; }
        public string Client { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "Image")]
        public byte[]? MainImage { get; set; }

        public List<ImagesShootDTO> ShootImages { get; set; }
    }
}
