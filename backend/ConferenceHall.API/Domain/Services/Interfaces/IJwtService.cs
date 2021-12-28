namespace ConferenceHall.API.Domain.Services.Interfaces;

public interface IJwtService
{
    string Generate(Guid id);
    bool Validate(string token);
}