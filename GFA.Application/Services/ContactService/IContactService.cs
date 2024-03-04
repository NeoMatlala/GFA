using GFA.Domain.DTOs;
using GFA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFA.Application.Services.ContactService
{
    public interface IContactService
    {
        List<Message> GetMessages();
        MessageResponse CreateMessage(MessageDTO model);

        MessageResponse GetMessage(int id);
    }
}
