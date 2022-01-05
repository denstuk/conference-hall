﻿using ConferenceHall.API.Domain.Users.Dtos;

namespace ConferenceHall.API.Domain.Messages.Dtos;

public class MessageResponseDto
{
    public Guid Id { get; set; }
    public string Text { get; set; } = default!;
    public UserResponseDto Creator { get; set; } = default!;
    public Guid ConferenceId { get; set; }
    public DateTime CreatedAt { get; set; }
}