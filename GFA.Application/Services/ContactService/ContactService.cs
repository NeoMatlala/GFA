using GFA.Domain.DTOs;
using GFA.Domain.Models;
using GFA.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFA.Application.Services.ContactService
{
    public class ContactService : IContactService
    {
        private readonly ApplicationDbContext _db;

        public ContactService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Message> GetMessages()
        {
            var messages = _db.Messages.ToList();

            return messages;
        }

        public MessageResponse GetMessage(int id)
        {
            try
            {
                var message = _db.Messages.Find(id);

                if(message == null)
                {
                    return new MessageResponse
                    {
                        Success = false,
                        Message = "Message does not exist."
                    };
                }

                message.IsRead = true;
                _db.SaveChanges();

                return new MessageResponse
                {
                    Success = true,
                    Message = "Message found.",
                    MessageObj = message
                };
            } 
            catch (Exception ex)
            {
                return new MessageResponse
                {
                    Success = false,
                    Message = $"Error getting message: {ex.Message}"
                };
            }
        }

        public MessageResponse CreateMessage(MessageDTO model)
        {
            try
            {
                var message = new Message
                {
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Subject = model.Subject,
                    MessageBody = model.MessageBody,
                    Email = model.Email
                };

                _db.Messages.Add(message);
                _db.SaveChanges();

                return new MessageResponse
                {
                    Success = true,
                    Message = "Your message was successfully sent. We'll get back to you shortly."
                };
            }
            catch (Exception ex)
            {
                return new MessageResponse
                {
                    Success = false,
                    Message = $"Error creating message: {ex.Message}"
                };
            }
        }
    }
}
