﻿namespace ConferenceHall.API.Domain.Users.Dtos;

public class SecureUserDto
{
    public string Login { get; set; } = default!;
    public string Email { get; set; } = default!;
}