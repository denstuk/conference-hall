using ConferenceHall.API.Domain.Users.Interfaces;
using MediatR;

namespace ConferenceHall.API.Domain.Users.Commands;

public class BlockUserCommand : IRequest
{
    public Guid Id { get; set; }
    public DateTime BlockedUntil { get; set; }
}

public class BlockUserCommandHandler : IRequestHandler<BlockUserCommand>
{
    private readonly IUserService _userService;
    public BlockUserCommandHandler(IUserService userService) => _userService = userService;
    
    public async Task<Unit> Handle(BlockUserCommand request, CancellationToken cancellationToken)
    {
        await _userService.BlockUser(request.Id, request.BlockedUntil);
        return Unit.Value;
    }
}