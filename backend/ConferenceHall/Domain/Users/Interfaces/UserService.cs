using ConferenceHall.Domain.Auth.Dtos;
using ConferenceHall.Domain.Users.Dtos;
using ConferenceHall.Domain.Users.Entities;

namespace ConferenceHall.Domain.Users.Interfaces;

public interface IUserService
{
    Task<List<UserEntity>> GetUsersFilter(FilterUserParams filterParams);
    Task<UserEntity> CreateUser(SignUpDto dto);
    Task DeleteUser(Guid id);
    Task BlockUser(Guid id, DateTime dateTime);
}