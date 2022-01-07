using ConferenceHall.Domain.Files.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceHall.Application.Http.Controllers;

public class FilesController : ApiController
{
    private readonly IFileService _fileService;

    public FilesController(IFileService fileService)
    {
        _fileService = fileService;
    }
    
    [HttpPost("")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult> UploadFile(IFormFileCollection uploads)
    {
        await _fileService.Upload(uploads);
        return Ok(Directory.GetCurrentDirectory());
    }
}