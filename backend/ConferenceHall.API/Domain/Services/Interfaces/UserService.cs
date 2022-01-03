using ConferenceHall.API.Domain.Auth.Dtos;
using ConferenceHall.API.Domain.Dtos;
using ConferenceHall.API.Domain.Entities;

namespace ConferenceHall.API.Domain.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserEntity>> GetUsersFilter();
    Task<UserEntity> CreateUser(SignUpDto dto);
}