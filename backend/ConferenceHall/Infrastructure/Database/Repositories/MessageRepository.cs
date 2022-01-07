using ConferenceHall.Domain.Messages.Dtos;
using ConferenceHall.Domain.Messages.Entities;
using ConferenceHall.Infrastructure.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConferenceHall.Infrastructure.Database.Repositories;

public class MessageRepository : BaseRepository<MessageEntity>, IMessageRepository
{
    public MessageRepository(DatabaseContext context) : base(context)
    {
    }

    public async Task<List<MessageEntity>> FilterList(FilterMessagesDto filterDto)
    {
        var qb = _dbSet.AsQueryable();
        if (filterDto.ConferenceId is not null) qb = qb.Where(m => m.ConferenceId == filterDto.ConferenceId);
        qb = qb.OrderByDescending(m => m.CreatedAt);
        qb = qb.Include(m => m.Creator);
        qb = qb.Include(m => m.Conference);
        return await qb.ToListAsync();
    }
}