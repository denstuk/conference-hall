using ConferenceHall.API.Domain.Conferences.Dtos;
using ConferenceHall.API.Domain.Conferences.Entities;
using ConferenceHall.API.Domain.Conferences.Interfaces;
using MediatR;

namespace ConferenceHall.API.Domain.Conferences.Handlers.Queries;

public class SearchConferencesQuery : FilterConferenceParams, IRequest<List<ConferenceEntity>> {}

public class SearchConferencesQueryHandler : IRequestHandler<SearchConferencesQuery, List<ConferenceEntity>>
{
    private readonly IConferenceService _conferenceService;
    public SearchConferencesQueryHandler(IConferenceService conferenceService) => _conferenceService = conferenceService;
    
    public async Task<List<ConferenceEntity>> Handle(SearchConferencesQuery request, CancellationToken cancellationToken)
    {
        var conferences = await _conferenceService.GetConferencesFilter(request);
        return conferences;
    }
}
