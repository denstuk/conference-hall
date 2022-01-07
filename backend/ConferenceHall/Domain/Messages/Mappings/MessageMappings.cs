using AutoMapper;
using ConferenceHall.Domain.Messages.Dtos;
using ConferenceHall.Domain.Messages.Entities;

namespace ConferenceHall.Domain.Messages.Mappings;

public class MessageMappings : Profile
{
    public MessageMappings()
    {
        CreateMap<CreateMessageDto, MessageEntity>();
        CreateMap<MessageEntity, MessageResponseDto>();
    }
}