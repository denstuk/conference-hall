using System.Security.Claims;
using ConferenceHall.Domain.Users.Dtos;
using ConferenceHall.Domain.Users.Entities;
using ConferenceHall.Infrastructure.Database.Repositories.Interfaces;

namespace ConferenceHall.Application.Http.Providers;

public class HttpProvider : IHttpProvider
{
    private readonly IUserRepository _userRepository;
    public HttpProvider(IUserRepository userRepository) => _userRepository = userRepository;

    public async Task<UserEntity> GetUser(HttpContext context)
    {
        var identity = context.User.Identity as ClaimsIdentity;
        if (identity is null) throw new Exception("Claims not found");
			
        string? id = identity.Claims.FirstOrDefault((o) => o.Type == ClaimTypes.NameIdentifier)?.Value;
        if (id is null) throw new Exception("Invalid token");

        List<UserEntity> users = await _userRepository.FilterList(new FilterUserParams()
        {
            Ids = new List<Guid>() { Guid.Parse(id) },
            Take = 1,
        });
        if (users.Count == 0) throw new Exception("User not found");

        return users[0];
    }

    public string GetIp(HttpContext context)
    {
        return context.Request.Headers["HTTP_X_FORWARDED_FOR"];
    }
}