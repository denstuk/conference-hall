namespace ConferenceHall.API.Domain.Files.Interfaces;

public interface IFileService
{
    Task Upload(IFormFileCollection uploads);
}