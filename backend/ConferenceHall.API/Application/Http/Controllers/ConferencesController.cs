using ConferenceHall.API.Domain.Conferences.Entities;
using ConferenceHall.API.Infrastructure.Database.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceHall.API.Application.Http.Controllers;

public class ConferencesController : ApiController
{
    private readonly IConferenceRepository _conferenceRepository;

    public ConferencesController(IConferenceRepository conferenceRepository)
    {
        _conferenceRepository = conferenceRepository;
    }
    
    
    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<ConferenceEntity>>> GetConferences()
    {
        var conferences = await _conferenceRepository.Get();
        return Ok(conferences);
    }
}