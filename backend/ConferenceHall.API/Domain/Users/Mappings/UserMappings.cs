using AutoMapper;
using ConferenceHall.API.Domain.Auth.Dtos;
using ConferenceHall.API.Domain.Users.Dtos;
using ConferenceHall.API.Domain.Users.Entities;

namespace ConferenceHall.API.Domain.Users.Mappings;

public class UserMappings : Profile
{
    public UserMappings()
    {
        CreateMap<SignUpDto, UserEntity>();
        CreateMap<UserEntity, SecureUserDto>();
    }
}