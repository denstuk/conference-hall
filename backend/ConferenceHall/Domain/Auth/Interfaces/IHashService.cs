namespace ConferenceHall.Domain.Auth.Interfaces;

public interface IHashService
{
    string GenerateSalt();
    string GeneratePassword(string salt, string password);
    bool TryPassword(string value, string salt, string password);
}