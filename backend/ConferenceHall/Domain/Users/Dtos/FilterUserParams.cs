namespace ConferenceHall.Domain.Users.Dtos;

public class FilterUserParams
{
    public List<Guid>? Ids { get; set; }
    public string? Email { get; set; }
    public string? Login { get; set; }
    public int? Take { get; set; } = 25;
    public int? Skip { get; set; } = 0;
    public bool? JoinConferences { get; set; } = false;
}