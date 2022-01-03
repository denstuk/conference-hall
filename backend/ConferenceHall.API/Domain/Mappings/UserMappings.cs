using AutoMapper;
using ConferenceHall.API.Domain.Auth.Dtos;
using ConferenceHall.API.Domain.Dtos;
using ConferenceHall.API.Domain.Entities;

namespace ConferenceHall.API.Domain.Mappings;

public class UserMappings : Profile
{
    public UserMappings()
    {
        CreateMap<SignUpDto, UserEntity>();
        CreateMap<UserEntity, SecureUserDto>();
    }
}