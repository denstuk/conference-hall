using ConferenceHall.API.Domain.Users.Entities;

namespace ConferenceHall.API.Application.Http.Providers;

public interface IHttpProvider
{
    Task<UserEntity> GetUser(HttpContext context);
    string GetIp(HttpContext context);
}