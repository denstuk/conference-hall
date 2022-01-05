using AutoMapper;
using ConferenceHall.API.Domain.Conferences.Dtos;
using ConferenceHall.API.Domain.Conferences.Entities;
using ConferenceHall.API.Domain.Conferences.Interfaces;
using ConferenceHall.API.Domain.Users.Entities;
using MediatR;

namespace ConferenceHall.API.Domain.Conferences.Handlers.Commands;

public class CreateConferenceCommand : IRequest<ResponseConferenceDto>
{
    public CreateConferenceDto CreateDto { get; set; } = new();
    public UserEntity Creator { get; set; } = new();
}

public class CreateConferenceCommandHandler : IRequestHandler<CreateConferenceCommand, ResponseConferenceDto>
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
    
    public async Task<ResponseConferenceDto> Handle(CreateConferenceCommand request, CancellationToken cancellationToken)
    {
        var conference = await _conferenceService.CreateConference(request.Creator, request.CreateDto);
        return _mapper.Map<ResponseConferenceDto>(conference);
    }
}