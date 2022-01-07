using ConferenceHall.Domain.Conferences.Entities;
using ConferenceHall.Domain.Messages.Dtos;
using ConferenceHall.Domain.Messages.Entities;
using ConferenceHall.Domain.Users.Entities;

namespace ConferenceHall.Domain.Messages.Interfaces;

public interface IMessageService
{
    Task<List<MessageEntity>> GetMessagesFilter(FilterMessagesDto dto);
    Task<MessageEntity> CreateMessage(CreateMessageDto dto, UserEntity userEntity, ConferenceEntity conferenceEntity);
}