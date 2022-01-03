using ConferenceHall.API.Domain.Auth.Dtos;
using ConferenceHall.API.Domain.Users.Dtos;
using ConferenceHall.API.Domain.Users.Entities;

namespace ConferenceHall.API.Domain.Users.Interfaces;

public interface IUserService
{
    Task<List<UserEntity>> GetUsersFilter(FilterUserParams filterParams);
    Task<UserEntity> CreateUser(SignUpDto dto);
}