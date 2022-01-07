using AutoMapper;
using ConferenceHall.Domain.Conferences.Dtos;
using ConferenceHall.Domain.Conferences.Interfaces;
using MediatR;

namespace ConferenceHall.Domain.Conferences.Handlers.Queries;

public class SearchConferencesQuery : FilterConferenceParams, IRequest<List<ConferenceResponseDto>> {}

public class SearchConferencesQueryHandler : IRequestHandler<SearchConferencesQuery, List<ConferenceResponseDto>>
{
    private readonly IConferenceService _conferenceService;
    private readonly IMapper _mapper;

    public SearchConferencesQueryHandler(IConferenceService conferenceService, IMapper mapper)
    {
        _conferenceService = conferenceService;
        _mapper = mapper;
    } 
    
    public async Task<List<ConferenceResponseDto>> Handle(SearchConferencesQuery request, CancellationToken cancellationToken)
    {
        var conferences = await _conferenceService.GetConferencesFilter(request);
        return _mapper.Map<List<ConferenceResponseDto>>(conferences);
    }
}
