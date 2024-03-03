using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GFA.Domain.Models;
using System.Threading.Tasks;

namespace GFA.Domain.DTOs
{
    public class SocialsResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Social? Link { get; set; }
    }
}
