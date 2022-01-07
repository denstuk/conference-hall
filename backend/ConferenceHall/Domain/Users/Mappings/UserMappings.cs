using AutoMapper;
using ConferenceHall.Domain.Auth.Dtos;
using ConferenceHall.Domain.Users.Dtos;
using ConferenceHall.Domain.Users.Entities;

namespace ConferenceHall.Domain.Users.Mappings;

public class UserMappings : Profile
{
    public UserMappings()
    {
        CreateMap<SignUpDto, UserEntity>();
        CreateMap<UserEntity, UserResponseDto>();
    }
}