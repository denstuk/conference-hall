using ConferenceHall.API.Domain.Messages.Dtos;
using ConferenceHall.API.Domain.Messages.Entities;

namespace ConferenceHall.API.Infrastructure.Database.Repositories.Interfaces;

public interface IMessageRepository : IBaseRepository<MessageEntity>
{
    Task<List<MessageEntity>> FilterList(FilterMessagesDto filterDto);
}