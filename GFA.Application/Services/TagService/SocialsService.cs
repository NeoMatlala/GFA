using GFA.Domain.DTOs;
using GFA.Domain.Models;
using GFA.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFA.Application.Services.TagService
{
    public class SocialsService : ISocialsService
    {
        private readonly ApplicationDbContext _db;

        public SocialsService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Social> GetLinks()
        {
            var links = _db.Socials.ToList();

            return links;
        }

        public SocialsResponse CreateLink(Social model)
        {
            try
            {
                var link = new Social
                {
                    Platform = model.Platform,
                    Link = model.Link
                };

                _db.Socials.Add(link);
                _db.SaveChanges();

                return new SocialsResponse
                {
                    Success = true,
                    Message = $"{link.Platform} social link successfully created"
                };
            }
            catch (Exception ex)
            {
                return new SocialsResponse
                {
                    Success = false,
                    Message = $"Error occured while saving link: {ex.Message}"
                };
            }
        }

        public SocialsResponse GetLink(int id)
        {
            var link = _db.Socials.Find(id);

            if(link == null)
            {
                return new SocialsResponse
                {
                    Success = false,
                    Message = "Link not found",
                };
            }

            return new SocialsResponse
            {
                Success = true,
                Message = "Link found",
                Link = link
            };
        }

        public SocialsResponse DeleteLink(int id)
        {
            var link = _db.Socials.Find(id);

            if (link == null)
            {
                return new SocialsResponse
                {
                    Success = false,
                    Message = "Link not found",
                };
            }

            try
            {
                _db.Socials.Remove(link);
                _db.SaveChanges();

                return new SocialsResponse
                {
                    Success = true,
                    Message = $"{link.Platform} link is deleted."
                };
            }
            catch (Exception ex)
            {
                return new SocialsResponse
                {
                    Success = false,
                    Message = $"Error deleting {link.Platform} link: {ex.Message}"
                };
            }

        }

        public SocialsResponse UpdateLink(int id, Social model)
        {
            var link = _db.Socials.Find(id);

            if (link == null)
            {
                return new SocialsResponse
                {
                    Success = false,
                    Message = "Link not found",
                };
            }

            try
            {
                if (!string.IsNullOrEmpty(model.Platform))
                {
                    link.Platform = model.Platform;
                }

                if (!string.IsNullOrEmpty(model.Link))
                {
                    link.Link = model.Link;
                }

                _db.Socials.Update(link);
                _db.SaveChanges();

                return new SocialsResponse
                {
                    Success = true,
                    Message = "link successfully updated",
                };
            }
            catch(Exception ex)
            {
                return new SocialsResponse
                {
                    Success = false,
                    Message = $"Error updating {link.Platform} link: {ex.Message}"
                };
            }
        }
    }
}
