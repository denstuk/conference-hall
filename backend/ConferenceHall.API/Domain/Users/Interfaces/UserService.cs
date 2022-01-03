using ConferenceHall.API.Domain.Auth.Dtos;
using ConferenceHall.API.Domain.Users.Entities;

namespace ConferenceHall.API.Domain.Users.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserEntity>> GetUsersFilter();
    Task<UserEntity> CreateUser(SignUpDto dto);
}