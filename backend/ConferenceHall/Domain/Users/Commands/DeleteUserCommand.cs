using ConferenceHall.Domain.Users.Interfaces;
using MediatR;
using Newtonsoft.Json;

namespace ConferenceHall.Domain.Users.Commands;

public class DeleteUserCommand : IRequest
{
    [JsonProperty("id")]
    public Guid Id { get; set; }
}

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserService _userService;
    public DeleteUserCommandHandler(IUserService userService) => _userService = userService;
    
    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await _userService.DeleteUser(request.Id);
        return Unit.Value;
    }
}