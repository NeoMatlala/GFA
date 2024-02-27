using GFA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFA.Application.Services.TagService
{
    public interface ITagService
    {
        List<Tag> GetTags(); 
    }
}
