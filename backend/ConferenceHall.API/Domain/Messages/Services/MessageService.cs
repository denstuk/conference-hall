using AutoMapper;
using ConferenceHall.API.Domain.Conferences.Entities;
using ConferenceHall.API.Domain.Messages.Dtos;
using ConferenceHall.API.Domain.Messages.Entities;
using ConferenceHall.API.Domain.Messages.Interfaces;
using ConferenceHall.API.Domain.Users.Entities;
using ConferenceHall.API.Infrastructure.Database.Repositories.Interfaces;

namespace ConferenceHall.API.Domain.Messages.Services;

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