using ConferenceHall.API.Domain.Users.Dtos;

namespace ConferenceHall.API.Domain.Messages.Dtos;

public class ResponseMessageDto
{
    public Guid Id { get; set; }
    public string Text { get; set; } = default!;
    public UserResponseDto Creator { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
}