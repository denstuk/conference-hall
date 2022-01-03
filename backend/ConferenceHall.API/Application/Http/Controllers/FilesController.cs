using ConferenceHall.API.Domain.FileSystem.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceHall.API.Application.Http.Controllers;

public class FilesController : ApiController
{
    private readonly IFileService _fileService;

    public FilesController(IFileService fileService)
    {
        _fileService = fileService;
    }
    
    [HttpPost("")]
    public async Task<ActionResult> UploadFile(IFormFileCollection uploads)
    {
        await _fileService.Upload(uploads);
        return Ok(Directory.GetCurrentDirectory());
    }
}