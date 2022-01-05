using System.ComponentModel.DataAnnotations;
using ConferenceHall.API.Domain.Auth.Dtos;
using ConferenceHall.API.Domain.Auth.Interfaces;
using ConferenceHall.API.Domain.Users.Dtos;
using ConferenceHall.API.Domain.Users.Entities;
using ConferenceHall.API.Domain.Users.Interfaces;
using MediatR;
using Newtonsoft.Json;

namespace ConferenceHall.API.Domain.Auth.Handlers.Commands;

public class SignUpCommand : SignUpDto, IRequest<TokenDto> {}

public class SignUpHandler : IRequestHandler<SignUpCommand, TokenDto>
{
    private readonly IUserService _userService;
    private readonly IJwtService _jwtService;

    public SignUpHandler(IUserService userService, IJwtService jwtService)
    {
        _userService = userService;
        _jwtService = jwtService;
    }
    
    public async Task<TokenDto> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        List<UserEntity> checkEmail = await _userService.GetUsersFilter(new FilterUserParams() { Email = request.Email });
        if (checkEmail.Count > 0) throw new Exception("Email already taken");

        List<UserEntity> checkLogin = await _userService.GetUsersFilter(new FilterUserParams() { Login = request.Login });
        if (checkLogin.Count > 0) throw new Exception("Login already taken");

        UserEntity user = await _userService.CreateUser(new SignUpDto()
        {
            Email = request.Email,
            Login = request.Login,
            Password = request.Password
        });
        
        string token = _jwtService.Generate(user.Id);
        return new TokenDto() { AccessToken = token };
    }
}
