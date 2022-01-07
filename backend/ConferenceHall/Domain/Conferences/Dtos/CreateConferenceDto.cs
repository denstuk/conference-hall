using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ConferenceHall.Domain.Conferences.Dtos;

public class CreateConferenceDto
{
    [Required]
    [MinLength(1)]
    [JsonProperty("title")]
    public string Title { get; set; } = default!;
}