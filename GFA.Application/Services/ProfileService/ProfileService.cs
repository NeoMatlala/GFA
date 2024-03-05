using GFA.Domain.Models;
using GFA.Infrastructure.Data;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using GFA.Domain.DTOs;

namespace GFA.Application.Services.ProfileService
{
    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext _db;

        public ProfileService(ApplicationDbContext db)
        {
            _db = db; 
        }

        public List<Profile> GetProfiles()
        {
            var profiles = _db.Profiles.ToList();

            return profiles;
        }

        public ProfileResponse CreateProfile(Profile model, IFormFile image)
        {
            try
            {
                var profile = new Profile
                {
                    Title = model.Title,
                    Bio = model.Bio,
                };

                using (MemoryStream stream = new MemoryStream())
                {
                    image.CopyTo(stream);
                    profile.Image = stream.ToArray();
                }

                _db.Profiles.Add(profile);
                _db.SaveChanges();

                return new ProfileResponse
                {
                    Success = true,
                    Message = "Profile created"
                };
            }
            catch (Exception ex)
            {
                return new ProfileResponse
                {
                    Success = false,
                    Message = $"Error creating profile: {ex.Message}"
                };
            }
        }

        public ProfileResponse UpdateProfile(int id, Profile model, IFormFile? image)
        {
            try
            {
                var profile = _db.Profiles.Find(id);

                if (profile == null)
                {
                    return new ProfileResponse
                    {
                        Success = false,
                        Message = "Profile does not exist"
                    };
                }

                if (!string.IsNullOrEmpty(model.Title))
                {
                    profile.Title = model.Title;
                }

                if (!string.IsNullOrEmpty(model.Bio))
                {
                    profile.Bio = model.Bio;
                }

                if (image != null)
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        image.CopyTo(stream);
                        profile.Image = stream.ToArray();
                    }
                }

                _db.Profiles.Update(profile);
                _db.SaveChanges();

                return new ProfileResponse
                {
                    Success = true,
                    Message = "Profile successfully updated"
                };
            }
            catch (Exception ex)
            {
                return new ProfileResponse
                {
                    Success = false,
                    Message = "Error updating profile: {ex.Message}"
                };
            }
        }
    }
}
