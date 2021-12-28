using System.Security.Cryptography;
using System.Text;
using ConferenceHall.API.Domain.Services.Interfaces;

namespace ConferenceHall.API.Domain.Services;

public class HashService : IHashService
{
    public string Create(string value)
    {
        byte[] bytes = Encoding.ASCII.GetBytes(value);
        byte[] salt = GenerateSalt(32);

        byte[] saltedPassword = new byte[bytes.Length + salt.Length];
        Buffer.BlockCopy(bytes, 0, saltedPassword, 0, bytes.Length);
        Buffer.BlockCopy(salt, 0, saltedPassword, bytes.Length, salt.Length);
        
        var sha256 = SHA256.Create();
        var hash = sha256.ComputeHash(saltedPassword);

        return Convert.ToBase64String(hash);
    }

    public bool IsSame(string value, string hash)
    {
        var hashedValue = Create(value);
        return hashedValue == hash;
    }


    private string GenerateSalt(int size)
    {
        var array = new byte[size];
        using var random = RandomNumberGenerator.Create();
        random.GetNonZeroBytes(array);
        return array;
    }
}