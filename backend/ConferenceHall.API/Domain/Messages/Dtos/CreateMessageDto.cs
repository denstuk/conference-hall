using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ConferenceHall.API.Domain.Messages.Dtos;

public class CreateMessageDto
{
    [Required]
    [MinLength(1)]
    [JsonProperty("text")]
    public string Text { get; set; } = default!;
}