namespace ConferenceHall.Domain.Files.Interfaces;

public interface IFileService
{
    Task Upload(IFormFileCollection uploads);
}