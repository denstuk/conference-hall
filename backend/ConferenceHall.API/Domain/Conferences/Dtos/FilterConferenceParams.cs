namespace ConferenceHall.API.Domain.Conferences.Dtos;

public class FilterConferenceParams
{
    public List<Guid>? Ids { get; set; }
    public string? Title { get; set; }
    public string? TitleLike { get; set; }
    public DateTime? CreatedAt { get; set; }
}