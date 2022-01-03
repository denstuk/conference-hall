using System.ComponentModel;
using ConferenceHall.API.Domain.Auth;
using ConferenceHall.API.Domain.Services;
using Xunit;

namespace ConferenceHall.Tests.Framework;

public class HashServiceTest
{
    [Fact]
    [Description("Generate password with same password and different salt")]
    public void Test_GeneratePassword_1()
    {
        HashService hashService = new HashService();
        string password = "password123";
        string hashedPassword1 = hashService.GeneratePassword(hashService.GenerateSalt(), password);
        string hashedPassword2 = hashService.GeneratePassword(hashService.GenerateSalt(), password);
        Assert.NotEqual(hashedPassword1, hashedPassword2);
    }

    [Fact]
    [Description("Generate password with same password and salt")]
    public void Test_GeneratePassword_2()
    {
        HashService hashService = new HashService();
        string password = "password123";
        string salt = hashService.GenerateSalt();
        string hashedPassword1 = hashService.GeneratePassword(salt, password);
        string hashedPassword2 = hashService.GeneratePassword(salt, password);
        Assert.Equal(hashedPassword1, hashedPassword2);
    }

    [Fact]
    [Description("Generate password and compare with same")]
    public void Test_TryPassword_1()
    {
        HashService hashService = new HashService();
        string password = "password123";
        string salt = hashService.GenerateSalt();
        string hashedPassword1 = hashService.GeneratePassword(salt, password);
        Assert.True(hashService.TryPassword(password, salt, hashedPassword1));
    }

    [Fact]
    [Description("Generate password and compare with different")]
    public void Test_TryPassword_2()
    {
        HashService hashService = new HashService();
        string password = "password123";
        string salt = hashService.GenerateSalt();
        string hashedPassword = hashService.GeneratePassword(salt, password);
        Assert.False(hashService.TryPassword("password125", salt, hashedPassword));
    }
}

