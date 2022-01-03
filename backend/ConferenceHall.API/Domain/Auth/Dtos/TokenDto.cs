using Newtonsoft.Json;

namespace ConferenceHall.API.Domain.Auth.Dtos;

public class TokenDto
{
    [JsonProperty("accessToken")] 
    public string AccessToken { get; set; } = default!;
}