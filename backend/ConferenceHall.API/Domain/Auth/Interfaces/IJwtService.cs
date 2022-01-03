namespace ConferenceHall.API.Domain.Auth.Interfaces;

public interface IJwtService
{
    string Generate(Guid id);
    bool Validate(string token);
}