using AutoMapper;
using ConferenceHall.API.Domain.Messages.Dtos;
using ConferenceHall.API.Domain.Messages.Entities;

namespace ConferenceHall.API.Domain.Messages.Mappings;

public class MessageMappings : Profile
{
    public MessageMappings()
    {
        CreateMap<CreateMessageDto, MessageEntity>();
    }
}