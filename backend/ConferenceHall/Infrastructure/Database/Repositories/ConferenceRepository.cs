using ConferenceHall.Domain.Conferences.Dtos;
using ConferenceHall.Domain.Conferences.Entities;
using ConferenceHall.Infrastructure.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConferenceHall.Infrastructure.Database.Repositories;

public class ConferenceRepository : BaseRepository<ConferenceEntity>, IConferenceRepository
{
    public ConferenceRepository(DatabaseContext context) : base(context)
    {
    }

    public async Task<List<ConferenceEntity>> FilterList(FilterConferenceParams filterParams)
    {
        var qb = _dbSet.AsQueryable();
        if (filterParams.Ids is not null) qb = qb.Where((c) => filterParams.Ids.Contains(c.Id));
        qb = qb.Include(c => c.Creator);
        qb = qb.OrderByDescending(x => x.CreatedAt);
        return await qb.ToListAsync();
    }
}