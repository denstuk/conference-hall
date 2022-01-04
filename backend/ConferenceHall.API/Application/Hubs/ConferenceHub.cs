using System.Text.RegularExpressions;
using Microsoft.AspNetCore.SignalR;

namespace ConferenceHall.API.Application.Hubs;

public class ConferenceHub : Hub
{
    public ConferenceHub()
    {
        
    }
    
    public async Task Join(ConnectionDto dto)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, dto.ConferenceId.ToString());
        await Clients.Group(dto.ConferenceId.ToString()).SendAsync($"LogConnection - {dto.Token}");
    }
}

public class ConnectionDto
{
    public string Token { get; set; } = default!;
    public Guid ConferenceId { get; set; }
}