using ConferenceHall.Domain.Messages.Dtos;
using ConferenceHall.Domain.Messages.Entities;

namespace ConferenceHall.Infrastructure.Database.Repositories.Interfaces;

public interface IMessageRepository : IBaseRepository<MessageEntity>
{
    Task<List<MessageEntity>> FilterList(FilterMessagesDto filterDto);
}