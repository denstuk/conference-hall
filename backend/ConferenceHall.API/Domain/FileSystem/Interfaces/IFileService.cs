namespace ConferenceHall.API.Domain.FileSystem.Interfaces;

public interface IFileService
{
    Task Upload(IFormFileCollection uploads);
}