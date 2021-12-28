namespace ConferenceHall.API.Domain.Services.Interfaces;

public interface IHashService
{
    string Create(string value);
    bool IsSame(string value, string hash);
}