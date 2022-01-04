using ConferenceHall.API.Domain.Messages.Entities;

namespace ConferenceHall.API.Infrastructure.Database.Repositories.Interfaces;

public class MessageRepository : BaseRepository<MessageEntity>, IMessageRepository
{
    public MessageRepository(DatabaseContext context) : base(context)
    {
    }
}