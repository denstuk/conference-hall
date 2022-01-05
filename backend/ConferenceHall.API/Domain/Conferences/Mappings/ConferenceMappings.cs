using AutoMapper;
using ConferenceHall.API.Domain.Conferences.Dtos;
using ConferenceHall.API.Domain.Conferences.Entities;

namespace ConferenceHall.API.Domain.Conferences.Mappings;

public class ConferenceMappings : Profile 
{
    public ConferenceMappings()
    {
        CreateMap<CreateConferenceDto, ConferenceEntity>();
        CreateMap<ConferenceEntity, ResponseConferenceDto>();
    }
}