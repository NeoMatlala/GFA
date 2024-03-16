using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFA.Domain.DTOs
{
    public class ShootResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public ShootImagesDTO? shootObj { get; set; }
    }
}
