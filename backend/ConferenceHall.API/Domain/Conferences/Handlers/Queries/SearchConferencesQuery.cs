using AutoMapper;
using ConferenceHall.API.Domain.Conferences.Dtos;
using ConferenceHall.API.Domain.Conferences.Interfaces;
using MediatR;

namespace ConferenceHall.API.Domain.Conferences.Handlers.Queries;

public class SearchConferencesQuery : FilterConferenceParams, IRequest<List<ResponseConferenceDto>> {}

public class SearchConferencesQueryHandler : IRequestHandler<SearchConferencesQuery, List<ResponseConferenceDto>>
{
    private readonly IConferenceService _conferenceService;
    private readonly IMapper _mapper;

    public SearchConferencesQueryHandler(IConferenceService conferenceService, IMapper mapper)
    {
        _conferenceService = conferenceService;
        _mapper = mapper;
    } 
    
    public async Task<List<ResponseConferenceDto>> Handle(SearchConferencesQuery request, CancellationToken cancellationToken)
    {
        var conferences = await _conferenceService.GetConferencesFilter(request);
        return _mapper.Map<List<ResponseConferenceDto>>(conferences);
    }
}
