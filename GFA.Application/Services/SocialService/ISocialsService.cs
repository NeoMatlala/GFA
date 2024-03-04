using GFA.Domain.DTOs;
using GFA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFA.Application.Services.SocialService
{
    public interface ISocialsService
    {
        List<Social> GetLinks();

        SocialsResponse GetLink(int id);

        SocialsResponse CreateLink(Social model);

        SocialsResponse DeleteLink(int id);

        SocialsResponse UpdateLink(int id, Social model);
    }
}
