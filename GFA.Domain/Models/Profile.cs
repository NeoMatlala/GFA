using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFA.Domain.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string Title { get; set; }
        public string Bio { get; set; }

        [Column(TypeName = "image")]
        public byte[]? Image { get; set; }
    }
}
