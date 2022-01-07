namespace ConferenceHall.Domain.Auth.Interfaces;

public interface IJwtService
{
    string Generate(Guid id);
    bool Validate(string token);
    Guid ExtractUserId(string token);
}