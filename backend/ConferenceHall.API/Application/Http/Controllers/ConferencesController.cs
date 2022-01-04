using ConferenceHall.API.Domain.Conferences.Entities;
using ConferenceHall.API.Domain.Conferences.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceHall.API.Application.Http.Controllers;

public class ConferencesController : ApiController
{
    private readonly IMediator _mediator;
    public ConferencesController(IMediator mediator) => _mediator = mediator;
    
    /// <summary>
    /// Search conferences
    /// </summary>
    [HttpPost("search")]
    public async Task<ActionResult<IEnumerable<ConferenceEntity>>> SearchConferences([FromBody] SearchConferencesQuery query)
    {
        var conferences = await _mediator.Send(query);
        return Ok(conferences);
    }
}