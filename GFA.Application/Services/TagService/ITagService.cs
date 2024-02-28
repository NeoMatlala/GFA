using GFA.Domain.DTOs;
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

        Tag GetTag(int id);

        Tag CreateTag(Tag model);

        TagResponse DeleteTag(int id);

        TagResponse UpdateTag(int id, Tag model);
    }
}
