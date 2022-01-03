using ConferenceHall.API.Application.Http.Providers;
using ConferenceHall.API.Domain.Auth.Dtos;
using ConferenceHall.API.Domain.Auth.Interfaces;
using ConferenceHall.API.Domain.Entities;
using ConferenceHall.API.Domain.Services.Interfaces;
using ConferenceHall.API.Infrastructure.Database.Repositories;
using ConferenceHall.API.Infrastructure.Database.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceHall.API.Application.Http.Controllers;

public class AuthController : ApiController
{
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;
    private readonly IJwtService _jwtService;
    private readonly IHttpProvider _httpProvider;
    private readonly IHashService _hashService;

    public AuthController(
        IUserRepository userRepository, 
        IUserService userService, 
        IJwtService jwtService, 
        IHttpProvider httpProvider,
        IHashService hashService)
    {
        _userRepository = userRepository;
        _userService = userService;
        _jwtService = jwtService;
        _httpProvider = httpProvider;
        _hashService = hashService;
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
    public async Task<ActionResult<string>> SingIn([FromBody] SignInDto dto)
    {
        List<UserEntity> users = await _userRepository.FilterList(new FilterListParams() { Email = dto.Email, Take = 1 });
        if (users.Count == 0) return NotFound("User not found");

        UserEntity user = users[0];
        if (!_hashService.TryPassword(dto.Password, user.Salt, user.Password)) return Unauthorized("Invalid password");
        
        string token = _jwtService.Generate(user.Id);
        return Ok(token);
    }

    [HttpGet("me")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult<UserEntity>> Me()
    {
        var user = await _httpProvider.GetUser(HttpContext);
        return Ok(user);
    }
}