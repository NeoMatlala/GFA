using GFA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GFA.Infrastructure.Data;
using GFA.Domain.DTOs;

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

        public Tag GetTag(int id)
        {
            var tag = _db.Tags.Find(id);

            return tag;
        }

        public Tag CreateTag(Tag model)
        {
            var tag = new Tag
            {
                TagName = model.TagName
            };

            _db.Tags.Add(tag);
            _db.SaveChanges();

            return tag;
        }

        public TagResponse UpdateTag(int id, Tag model)
        {
            var tag = _db.Tags.Find(id);

            if (tag == null)
            {
                return new TagResponse
                {
                    Success = false,
                    Message = "Tag not found"
                };
            }

            if (!string.IsNullOrEmpty(model.TagName))
            {
                tag.TagName = model.TagName;
            }

            _db.Tags.Update(tag);
            _db.SaveChanges();

            return new TagResponse
            {
                Success = true,
                Message = "Tag updated"
            };
        }

        public TagResponse DeleteTag(int id)
        {
            var tag = _db.Tags.Find(id);

            if (tag == null)
            {
                return new TagResponse
                {
                    Success = false,
                    Message = "Tag not found"
                };
            }

            _db.Tags.Remove(tag);
            _db.SaveChanges();

            return new TagResponse { Success = true };
        }

    }
}
