using ConferenceHall.API.Application.Http.Providers;
using ConferenceHall.API.Domain.Dtos;
using ConferenceHall.API.Domain.Entities;
using ConferenceHall.API.Domain.Services.Interfaces;
using ConferenceHall.API.Infrastructure.Database.Repositories;
using ConferenceHall.API.Infrastructure.Database.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceHall.API.Application.Http.Controllers;

public class AuthController : ApiController
{
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;
    private readonly IJwtService _jwtService;
    private readonly IHttpProvider _httpProvider;

    public AuthController(IUserRepository userRepository, IUserService userService, IJwtService jwtService, IHttpProvider httpProvider)
    {
        _userRepository = userRepository;
        _userService = userService;
        _jwtService = jwtService;
        _httpProvider = httpProvider;
    }
    
    [HttpPost("sign-up")]
    public async Task<ActionResult<string>> SignUp([FromBody] SignUpDto dto)
    {
        List<UserEntity> checkEmail = await _userRepository.FilterList(new FilterListParams() { Email = dto.Email });
        if (checkEmail.Count > 0) return Conflict("Email already taken");

        List<UserEntity> checkLogin = await _userRepository.FilterList(new FilterListParams() { Login = dto.Login });
        if (checkLogin.Count > 0) return Conflict("Login already taken");

        UserEntity user = await _userService.CreateUser(dto);
        string token = _jwtService.Generate(user.Id);
        
        return Ok(token);
    }

    [HttpPost("sign-in")]
    public async Task<ActionResult> SingIn([FromBody] FilterListParams filterParams)
    {
        return Ok(await _userRepository.FilterList(filterParams));
    }

    [HttpGet("me")]
    public async Task<ActionResult<UserEntity>> Me()
    {
        var user = await _httpProvider.GetUser(HttpContext);
        return Ok(user);
    }
}