using ConferenceHall.API.Domain.Conferences.Dtos;
using ConferenceHall.API.Domain.Conferences.Entities;
using ConferenceHall.API.Domain.Users.Entities;

namespace ConferenceHall.API.Domain.Conferences.Interfaces;

public interface IConferenceService
{
    Task<List<ConferenceEntity>> GetConferencesFilter(FilterConferenceParams filterParams);
    Task<ConferenceEntity> CreateConference(UserEntity creator, CreateConferenceDto dto);
    Task<ConferenceEntity> UpdateConference(Guid id, UpdateConferenceDto dto);
    Task DeleteConference(Guid id);
}