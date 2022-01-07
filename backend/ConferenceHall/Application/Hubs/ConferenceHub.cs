using AutoMapper;
using ConferenceHall.Domain.Auth.Interfaces;
using ConferenceHall.Domain.Conferences.Dtos;
using ConferenceHall.Domain.Conferences.Interfaces;
using ConferenceHall.Domain.Messages.Dtos;
using ConferenceHall.Domain.Messages.Interfaces;
using ConferenceHall.Domain.Users.Dtos;
using ConferenceHall.Domain.Users.Entities;
using ConferenceHall.Domain.Users.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace ConferenceHall.Application.Hubs;

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
        if (_connections.TryGetValue(Context.ConnectionId, out ConnectionDto? connection))
        {
            var user = await ExtractUserFromToken(connection.Token);
            var conferences = await _conferenceService.GetConferencesFilter(new FilterConferenceParams()
                { Ids = new List<Guid>() { Guid.Parse(connection.ConferenceId) } });
            if (conferences.Count == 0)
            {
                throw new Exception("Conference not found");
            }

            var message = await _messageService.CreateMessage(new CreateMessageDto() { Text = sendMessageDto.Text }, user, conferences[0]);
            await Clients.Group(connection.ConferenceId)
                .SendAsync("ReceiveMessage", _mapper.Map<MessageResponseDto>(message));
        }
    }
    
    public async Task Join(ConnectionDto dto)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, dto.ConferenceId);
        _connections[Context.ConnectionId] = dto;
        await base.OnConnectedAsync();
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
    public string ConferenceId { get; set; } = default!;
}

public class SendMessageDto
{
    public string Text { get; set; } = default!;
}