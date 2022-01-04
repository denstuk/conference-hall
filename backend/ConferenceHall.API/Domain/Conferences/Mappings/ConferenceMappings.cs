using AutoMapper;
using ConferenceHall.API.Domain.Conferences.Entities;
using ConferenceHall.API.Domain.Users.Dtos;

namespace ConferenceHall.API.Domain.Conferences.Mappings;

public class ConferenceMappings : Profile 
{
    public ConferenceMappings()
    {
        CreateMap<CreateConferenceDto, ConferenceEntity>();
    }
}