using ConferenceHall.API.Application.Http.Providers;
using ConferenceHall.API.Domain.Conferences.Dtos;
using ConferenceHall.API.Domain.Conferences.Handlers.Commands;
using ConferenceHall.API.Domain.Conferences.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceHall.API.Application.Http.Controllers;

public class ConferencesController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IHttpProvider _provider;

    public ConferencesController(IMediator mediator, IHttpProvider provider)
    {
        _mediator = mediator;
        _provider = provider;
    }
    
    /// <summary>
    /// Search conferences
    /// </summary>
    [HttpPost("search")]
    public async Task<ActionResult<IEnumerable<ResponseConferenceDto>>> SearchConferences([FromBody] SearchConferencesQuery query)
    {
        var conferences = await _mediator.Send(query);
        return Ok(conferences);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPost("")]
    public async Task<ActionResult<ResponseConferenceDto>> CreateConference([FromBody] CreateConferenceDto dto)
    {
        var user = await _provider.GetUser(HttpContext);
        var conference = await _mediator.Send(new CreateConferenceCommand() { CreateDto = dto, Creator = user, });
        return Ok(conference);
    }
}