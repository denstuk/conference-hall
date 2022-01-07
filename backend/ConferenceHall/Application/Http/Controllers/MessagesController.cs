using ConferenceHall.Domain.Messages.Dtos;
using ConferenceHall.Domain.Messages.Handler.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceHall.Application.Http.Controllers;

public class MessagesController : ApiController
{
    private readonly IMediator _mediator;

    public MessagesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("search")]
    public async Task<ActionResult<List<MessageResponseDto>>> SearchMessages([FromBody] FilterMessagesDto dto)
    {
        var messages = await _mediator.Send(new SearchMessagesQuery()
        {
            ConferenceId = dto.ConferenceId
        });
        return Ok(messages);
    }
}