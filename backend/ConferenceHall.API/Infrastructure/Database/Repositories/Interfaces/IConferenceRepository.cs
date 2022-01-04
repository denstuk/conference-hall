using ConferenceHall.API.Domain.Conferences.Dtos;
using ConferenceHall.API.Domain.Conferences.Entities;

namespace ConferenceHall.API.Infrastructure.Database.Repositories.Interfaces;

public interface IConferenceRepository : IBaseRepository<ConferenceEntity>
{
    Task<List<ConferenceEntity>> FilterList(FilterConferenceParams filterParams);
}