using ConferenceHall.Domain.Conferences.Dtos;
using ConferenceHall.Domain.Conferences.Entities;

namespace ConferenceHall.Infrastructure.Database.Repositories.Interfaces;

public interface IConferenceRepository : IBaseRepository<ConferenceEntity>
{
    Task<List<ConferenceEntity>> FilterList(FilterConferenceParams filterParams);
}