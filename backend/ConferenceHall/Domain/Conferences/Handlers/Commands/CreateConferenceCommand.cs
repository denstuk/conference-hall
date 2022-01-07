using AutoMapper;
using ConferenceHall.Domain.Conferences.Entities;
using ConferenceHall.Domain.Conferences.Dtos;
using ConferenceHall.Domain.Conferences.Interfaces;
using ConferenceHall.Domain.Users.Entities;
using MediatR;

namespace ConferenceHall.Domain.Conferences.Handlers.Commands;

public class CreateConferenceCommand : IRequest<ConferenceResponseDto>
{
    public CreateConferenceDto CreateDto { get; set; } = new();
    public UserEntity Creator { get; set; } = new();
}

public class CreateConferenceCommandHandler : IRequestHandler<CreateConferenceCommand, ConferenceResponseDto>
{
    private readonly IConferenceService _conferenceService;
    private readonly IMapper _mapper;

    public CreateConferenceCommandHandler(
        IConferenceService conferenceService,
        IMapper mapper)
    {
        _conferenceService = conferenceService;
        _mapper = mapper;
    }
    
    public async Task<ConferenceResponseDto> Handle(CreateConferenceCommand request, CancellationToken cancellationToken)
    {
        var conference = await _conferenceService.CreateConference(request.Creator, request.CreateDto);
        return _mapper.Map<ConferenceResponseDto>(conference);
    }
}