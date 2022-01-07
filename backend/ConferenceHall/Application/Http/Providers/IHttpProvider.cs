using ConferenceHall.Domain.Users.Entities;

namespace ConferenceHall.Application.Http.Providers;

public interface IHttpProvider
{
    Task<UserEntity> GetUser(HttpContext context);
    string GetIp(HttpContext context);
}