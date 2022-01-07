using AutoMapper;
using ConferenceHall.Domain.Conferences.Dtos;
using ConferenceHall.Domain.Conferences.Entities;
using ConferenceHall.Domain.Conferences.Interfaces;
using ConferenceHall.Domain.Users.Entities;
using ConferenceHall.Infrastructure.Database.Repositories.Interfaces;

namespace ConferenceHall.Domain.Conferences.Services;

public class ConferenceService : IConferenceService
{
    private readonly IConferenceRepository _conferenceRepository;
    private readonly IMapper _mapper;

    public ConferenceService(IConferenceRepository conferenceRepository, IMapper mapper)
    {
        _conferenceRepository = conferenceRepository;
        _mapper = mapper;
    }
    
    public Task<List<ConferenceEntity>> GetConferencesFilter(FilterConferenceParams filterParams)
    {
        return _conferenceRepository.FilterList(filterParams);
    }

    public async Task<ConferenceEntity> CreateConference(UserEntity creator, CreateConferenceDto dto)
    {
        var conference = _mapper.Map<ConferenceEntity>(dto);
        conference.CreatorId = creator.Id;

        await _conferenceRepository.Insert(conference);
        return conference;
    }

    public async Task<ConferenceEntity> UpdateConference(Guid id, UpdateConferenceDto dto)
    {
        var conferences = await _conferenceRepository.FilterList(new FilterConferenceParams()
            { Ids = new List<Guid>() { id } });
        if (conferences.Count == 0)
        {
            throw new Exception("Conference not found");
        }
        
        if (dto.Title is not null) conferences[0].Title = dto.Title;
        
        await _conferenceRepository.Update(conferences[0]);
        return conferences[0];
    }

    public async Task DeleteConference(Guid id)
    {
        var conferences = await _conferenceRepository.FilterList(new FilterConferenceParams()
            { Ids = new List<Guid>() { id } });
        if (conferences.Count == 0)
        {
            throw new Exception("Conference not found");
        }
        await _conferenceRepository.Delete(conferences[0]);
    }
}