using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ConferenceHall.API.Domain.Auth.Dtos;
public class SignUpDto
{
    [MinLength(1)] 
    [JsonProperty("login")]
    public string Login { get; set; } = default!;

    [EmailAddress]
    [JsonProperty("email")]
    public string Email { get; set; } = default!;

    [MinLength(8)]
    [JsonProperty("password")]
    public string Password { get; set; } = default!;
}