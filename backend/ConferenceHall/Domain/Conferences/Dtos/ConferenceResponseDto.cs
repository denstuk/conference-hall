using ConferenceHall.Domain.Messages.Dtos;
using ConferenceHall.Domain.Users.Dtos;

namespace ConferenceHall.Domain.Conferences.Dtos;

public class ConferenceResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public UserResponseDto Creator { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public List<MessageResponseDto> Messages { get; set; } = new List<MessageResponseDto>();
}