using GFA.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GFA.Domain.DTOs
{
    public class UpdateShootDTO
    {
        public string? Name { get; set; }
        public string? Client { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }

        public byte[]? MainImage { get; set; }

        // navigation property
        [JsonIgnore]
        public List<ShootImages>? ShootImages { get; set; }
    }
}
