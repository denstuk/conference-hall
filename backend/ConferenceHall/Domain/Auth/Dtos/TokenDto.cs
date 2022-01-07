using Newtonsoft.Json;

namespace ConferenceHall.Domain.Auth.Dtos;

public class TokenDto
{
    [JsonProperty("accessToken")] 
    public string AccessToken { get; set; } = default!;
}