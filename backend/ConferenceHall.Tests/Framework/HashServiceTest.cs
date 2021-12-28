using ConferenceHall.API.Domain.Services;
using Xunit;

namespace ConferenceHall.Tests.Framework;

public class HashServiceTest
{
    [Fact]
    public void Test_Create_ShouldReturnHash()
    {
        HashService hashService = new HashService();
        string password = hashService.Create("password123");
        Assert.NotEqual("password123", password);
    }

    [Fact]
    public void Test_Create_ShouldNotBeEqual()
    {
        HashService hashService = new HashService();
        string password1 = hashService.Create("password123");
        string password2 = hashService.Create("password123");
        Assert.NotEqual(password1, password2);
    }

    [Fact]
    public void Test_IsSame_ShouldBeTrue()
    {
        
    }
}