using ConferenceHall.API.Domain.Conferences.Entities;
using ConferenceHall.API.Domain.Messages.Dtos;
using ConferenceHall.API.Domain.Messages.Entities;
using ConferenceHall.API.Domain.Users.Entities;

namespace ConferenceHall.API.Domain.Messages.Interfaces;

public interface IMessageService
{
    Task<List<MessageEntity>> GetMessagesFilter(FilterMessagesDto dto);
    Task<MessageEntity> CreateMessage(CreateMessageDto dto, UserEntity userEntity, ConferenceEntity conferenceEntity);
}