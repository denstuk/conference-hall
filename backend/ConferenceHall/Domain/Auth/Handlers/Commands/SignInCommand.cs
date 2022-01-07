using ConferenceHall.Domain.Auth.Dtos;
using ConferenceHall.Domain.Auth.Interfaces;
using ConferenceHall.Domain.Users.Dtos;
using ConferenceHall.Domain.Users.Entities;
using ConferenceHall.Domain.Users.Interfaces;
using MediatR;

namespace ConferenceHall.Domain.Auth.Handlers.Commands;

public class SignInCommand : SignInDto, IRequest<TokenDto> {}
public class SignInCommandHandler : IRequestHandler<SignInCommand, TokenDto>
{
    private readonly IUserService _userService;
    private readonly IHashService _hashService;
    private readonly IJwtService _jwtService;

    public SignInCommandHandler(IUserService userService, IHashService hashService, IJwtService jwtService)
    {
        _userService = userService;
        _hashService = hashService;
        _jwtService = jwtService;
    }
    
    public async Task<TokenDto> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        List<UserEntity> users = await _userService.GetUsersFilter(new FilterUserParams() { Email = request.Email, Take = 1 });
        if (users.Count == 0) throw new Exception("User not found");

        UserEntity user = users[0];
        if (!_hashService.TryPassword(request.Password, user.Salt, user.Password)) throw new Exception("Invalid password");
        
        string token = _jwtService.Generate(user.Id);
        return new TokenDto() { AccessToken = token };
    }
}