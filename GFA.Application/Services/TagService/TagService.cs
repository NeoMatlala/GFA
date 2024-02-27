using GFA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GFA.Infrastructure.Data;

namespace GFA.Application.Services.TagService
{
    
    public class TagService : ITagService
    {
        private readonly ApplicationDbContext _db;

        public TagService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Tag> GetTags()
        {
            var tags = _db.Tags.ToList();

            return tags;
        }

    }
}
