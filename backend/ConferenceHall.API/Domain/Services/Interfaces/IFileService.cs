namespace ConferenceHall.API.Domain.Services.Interfaces;

public interface IFileService
{
    Task Upload(IFormFileCollection uploads);
}