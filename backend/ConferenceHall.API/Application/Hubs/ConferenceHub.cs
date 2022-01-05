using AutoMapper;
using ConferenceHall.API.Domain.Auth.Interfaces;
using ConferenceHall.API.Domain.Conferences.Dtos;
using ConferenceHall.API.Domain.Conferences.Interfaces;
using ConferenceHall.API.Domain.Messages.Dtos;
using ConferenceHall.API.Domain.Messages.Interfaces;
using ConferenceHall.API.Domain.Users.Dtos;
using ConferenceHall.API.Domain.Users.Entities;
using ConferenceHall.API.Domain.Users.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace ConferenceHall.API.Application.Hubs;

public class ConferenceHub : Hub
{
    private readonly IJwtService _jwtService;
    private readonly IUserService _userService;
    private readonly IDictionary<string, ConnectionDto> _connections;
    private readonly IConferenceService _conferenceService;
    private readonly IMessageService _messageService;
    private readonly IMapper _mapper;

    public ConferenceHub(
        IJwtService jwtService, 
        IUserService userService,
        IConferenceService conferenceService,
        IMessageService messageService,
        IMapper mapper,
        IDictionary<string, ConnectionDto> connections)
    {
        _jwtService = jwtService;
        _userService = userService;
        _conferenceService = conferenceService;
        _messageService = messageService;
        _connections = connections;
        _mapper = mapper;
    }

    public async Task SendMessage(SendMessageDto sendMessageDto)
    {
        if (_connections.TryGetValue(Context.ConnectionId, out ConnectionDto connection))
        {
            var user = await ExtractUserFromToken(connection.Token);
            var conferences = await _conferenceService.GetConferencesFilter(new FilterConferenceParams()
                { Ids = new List<Guid>() { Guid.Empty } });
            if (conferences.Count == 0)
            {
                throw new Exception("Conference not found");
            }

            var message = await _messageService.CreateMessage(new CreateMessageDto() { Text = sendMessageDto.Text }, user, conferences[0]);
            await Clients.Group(connection.ConferenceId.ToString())
                .SendAsync("ReceiveMessage", _mapper.Map<ResponseMessageDto>(message));
        }
    }
    
    public async Task Join(ConnectionDto dto)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, dto.ConferenceId.ToString());
        _connections[Context.ConnectionId] = dto;
        await base.OnConnectedAsync();
        //await Clients.Group(dto.ConferenceId.ToString()).SendAsync($"LogConnection - {dto.Token}");
    }

    private async Task<UserEntity> ExtractUserFromToken(string token)
    {
        Guid userId = _jwtService.ExtractUserId(token);
        
        List<UserEntity> users =
            await _userService.GetUsersFilter(new FilterUserParams() { Ids = new List<Guid>() { userId } });
        if (users.Count == 0)
        {
            throw new Exception("User not found");
        }

        return users[0];
    }
}

public class ConnectionDto
{
    public string Token { get; set; } = default!;
    public string ConferenceId { get; set; }
}

public class SendMessageDto
{
    public string Text { get; set; }
}