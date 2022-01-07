using Newtonsoft.Json;

namespace ConferenceHall.Domain.Messages.Dtos;

public class FilterMessagesDto
{
    [JsonProperty("conferenceId")]
    public Guid? ConferenceId { get; set; }
}