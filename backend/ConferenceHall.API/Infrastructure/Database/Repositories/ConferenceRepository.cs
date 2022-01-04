using ConferenceHall.API.Domain.Conferences.Dtos;
using ConferenceHall.API.Domain.Conferences.Entities;
using ConferenceHall.API.Infrastructure.Database.Repositories.Interfaces;

namespace ConferenceHall.API.Infrastructure.Database.Repositories;

public class ConferenceRepository : BaseRepository<ConferenceEntity>, IConferenceRepository
{
    public ConferenceRepository(DatabaseContext context) : base(context)
    {
    }

    public Task<List<ConferenceEntity>> FilterList(FilterConferenceParams filterParams)
    {
        throw new NotImplementedException();
    }
}