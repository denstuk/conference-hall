using ConferenceHall.Domain.Users.Enums;

namespace ConferenceHall.Domain.Users.Dtos;

public class UserResponseDto
{
    public Guid Id { get; set; }
    public string Login { get; set; } = default!;
    public string Email { get; set; } = default!;
    public UserRole Role { get; set; }
    public DateTime CreatedAt { get; set; }
}