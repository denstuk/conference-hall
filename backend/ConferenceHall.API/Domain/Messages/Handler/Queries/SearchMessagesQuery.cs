using AutoMapper;
using ConferenceHall.API.Domain.Messages.Dtos;
using ConferenceHall.API.Domain.Messages.Interfaces;
using MediatR;

namespace ConferenceHall.API.Domain.Messages.Handler.Queries;

public class SearchMessagesQuery : FilterMessagesDto, IRequest<List<MessageResponseDto>> {}

public class SearchMessagesQueryHandler : IRequestHandler<SearchMessagesQuery, List<MessageResponseDto>>
{
    private readonly IMessageService _messageService;
    private readonly IMapper _mapper;

    public SearchMessagesQueryHandler(IMessageService messageService, IMapper mapper)
    {
        _messageService = messageService;
        _mapper = mapper;
    }
    
    public async Task<List<MessageResponseDto>> Handle(SearchMessagesQuery request, CancellationToken cancellationToken)
    {
        var messages = await _messageService.GetMessagesFilter(request);
        return _mapper.Map<List<MessageResponseDto>>(messages);
    }
}
