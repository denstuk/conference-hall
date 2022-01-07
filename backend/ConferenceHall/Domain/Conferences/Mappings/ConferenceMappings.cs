using AutoMapper;
using ConferenceHall.Domain.Conferences.Dtos;
using ConferenceHall.Domain.Conferences.Entities;

namespace ConferenceHall.Domain.Conferences.Mappings;

public class ConferenceMappings : Profile 
{
    public ConferenceMappings()
    {
        CreateMap<CreateConferenceDto, ConferenceEntity>();
        CreateMap<ConferenceEntity, ConferenceResponseDto>();
    }
}