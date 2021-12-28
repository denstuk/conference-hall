using ConferenceHall.API.Domain.Entities;
using ConferenceHall.API.Infrastructure.Database.Repositories.Interfaces;

namespace ConferenceHall.API.Infrastructure.Database.Repositories;

public class ConferenceRepository : BaseRepository<ConferenceEntity>, IConferenceRepository
{
    public ConferenceRepository(DatabaseContext context) : base(context)
    {
    }
}