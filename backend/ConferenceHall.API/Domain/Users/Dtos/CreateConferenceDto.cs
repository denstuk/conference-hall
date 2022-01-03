namespace ConferenceHall.API.Domain.Users.Dtos;

public class CreateConferenceDto
{
    public string Title { get; set; } = default!;
    public List<Guid> UserIds { get; set; } = default!;
}