using Newtonsoft.Json;

namespace ConferenceHall.Domain.Auth.Dtos;

public class SignInDto
{
    [JsonProperty("email")] 
    public string Email { get; set; } = default!;

    [JsonProperty("password")] 
    public string Password { get; set; } = default!;
}
