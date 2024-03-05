using GFA.Domain.DTOs;
using GFA.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFA.Application.Services.ProfileService
{
    public interface IProfileService
    {
        List<Profile> GetProfiles();

        ProfileResponse CreateProfile(Profile model, IFormFile image);

        ProfileResponse UpdateProfile(int id, Profile model, IFormFile? image);
    }
}
