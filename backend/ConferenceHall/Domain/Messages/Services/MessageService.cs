using AutoMapper;
using ConferenceHall.Domain.Conferences.Entities;
using ConferenceHall.Domain.Messages.Dtos;
using ConferenceHall.Domain.Messages.Entities;
using ConferenceHall.Domain.Messages.Interfaces;
using ConferenceHall.Domain.Users.Entities;
using ConferenceHall.Infrastructure.Database.Repositories.Interfaces;

namespace ConferenceHall.Domain.Messages.Services;

public class MessageService : IMessageService
{
    private readonly IMessageRepository _messageRepository;
    private readonly IMapper _mapper;

    public MessageService(IMessageRepository messageRepository, IMapper mapper)
    {
        _messageRepository = messageRepository;
        _mapper = mapper;
    }
    
    public Task<List<MessageEntity>> GetMessagesFilter(FilterMessagesDto dto)
    {
        return _messageRepository.FilterList(dto);
    }

    public async Task<MessageEntity> CreateMessage(CreateMessageDto dto, UserEntity userEntity, ConferenceEntity conferenceEntity)
    {
        var message = _mapper.Map<MessageEntity>(dto);
        message.Conference = conferenceEntity;
        message.Creator = userEntity;
        await _messageRepository.Insert(message);
        return message;
    }
}