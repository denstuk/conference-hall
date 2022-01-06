using ConferenceHall.API.Domain.Messages.Entities;
using ConferenceHall.API.Domain.Users.Dtos;

namespace ConferenceHall.API.Domain.Conferences.Dtos;

public class ConferenceResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public UserResponseDto Creator { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public List<MessageEntity> Messages { get; set; } = new List<MessageEntity>();
}