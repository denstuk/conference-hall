using ConferenceHall.Domain.Conferences.Dtos;
using ConferenceHall.Domain.Conferences.Entities;
using ConferenceHall.Domain.Users.Entities;

namespace ConferenceHall.Domain.Conferences.Interfaces;

public interface IConferenceService
{
    Task<List<ConferenceEntity>> GetConferencesFilter(FilterConferenceParams filterParams);
    Task<ConferenceEntity> CreateConference(UserEntity creator, CreateConferenceDto dto);
    Task<ConferenceEntity> UpdateConference(Guid id, UpdateConferenceDto dto);
    Task DeleteConference(Guid id);
}