using System.Security.Cryptography;
using System.Text;
using ConferenceHall.API.Domain.Auth.Interfaces;

namespace ConferenceHall.API.Domain.Auth;

public class HashService : IHashService
{
    public string GenerateSalt()
    {
        using var random = RandomNumberGenerator.Create();
        byte[] salt = new byte[12];
        random.GetBytes(salt);
        return Convert.ToBase64String(salt);
    }

    public string GeneratePassword(string salt, string password)
    {
        byte[] passBinary = Encoding.ASCII.GetBytes(password);
        byte[] saltBinary = Encoding.ASCII.GetBytes(salt);
        
        byte[] saltedPassword = new byte[passBinary.Length + saltBinary.Length];
        Buffer.BlockCopy(passBinary, 0, saltedPassword, 0, passBinary.Length);
        Buffer.BlockCopy(saltBinary, 0, saltedPassword, passBinary.Length, saltBinary.Length);
        
        var sha256 = SHA256.Create();
        var hash = sha256.ComputeHash(saltedPassword);

        return Convert.ToBase64String(hash);
    }

    public bool TryPassword(string value, string salt, string password) => GeneratePassword(salt, value) == password;
}