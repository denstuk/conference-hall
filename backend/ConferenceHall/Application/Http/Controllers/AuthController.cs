using AutoMapper;
using ConferenceHall.Application.Http.Providers;
using ConferenceHall.Domain.Auth.Dtos;
using ConferenceHall.Domain.Auth.Handlers.Commands;
using ConferenceHall.Domain.Users.Dtos;
using ConferenceHall.Domain.Users.Entities;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceHall.Application.Http.Controllers;

public class AuthController : ApiController
{
    private readonly IHttpProvider _httpProvider;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthController(IHttpProvider httpProvider, IMediator mediator, IMapper mapper)
    {
        _httpProvider = httpProvider;
        _mediator = mediator;
        _mapper = mapper;
    }
    
    [HttpPost("sign-up")]
    public async Task<ActionResult<TokenDto>> SignUp([FromBody] SignUpCommand command)
    {
        var token = await _mediator.Send(command);
        return Ok(token);
    }

    [HttpPost("sign-in")]
    public async Task<ActionResult<string>> SingIn([FromBody] SignInCommand command)
    {
        var token = await _mediator.Send(command);
        return Ok(token);
    }

    [HttpGet("me")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult<UserResponseDto>> Me()
    {
        var user = await _httpProvider.GetUser(HttpContext);
        return Ok(_mapper.Map<UserResponseDto>(user));
    }
}