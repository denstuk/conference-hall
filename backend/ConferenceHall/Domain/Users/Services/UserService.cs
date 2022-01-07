using AutoMapper;
using ConferenceHall.Domain.Auth.Dtos;
using ConferenceHall.Domain.Auth.Interfaces;
using ConferenceHall.Domain.Users.Dtos;
using ConferenceHall.Domain.Users.Entities;
using ConferenceHall.Domain.Users.Interfaces;
using ConferenceHall.Infrastructure.Database.Repositories.Interfaces;

namespace ConferenceHall.Domain.Users.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IHashService _hashService;

    public UserService(IUserRepository userRepository, IMapper mapper, IHashService hashService)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _hashService = hashService;
    }

    public Task<List<UserEntity>> GetUsersFilter(FilterUserParams filterParams)
    {
        return _userRepository.FilterList(filterParams);
    }

    public async Task<UserEntity> CreateUser(SignUpDto dto)
    {
        var user = _mapper.Map<UserEntity>(dto);
        user.Salt = _hashService.GenerateSalt();
        user.Password = _hashService.GeneratePassword(user.Salt, dto.Password);
        await _userRepository.Insert(user);
        return user;
    }

    public async Task DeleteUser(Guid id)
    {
        var users = await _userRepository.FilterList(new FilterUserParams() { Ids = new List<Guid>() { id } });
        if (users.Count == 0)
        {
            throw new Exception("User not found");
        }
        await _userRepository.Delete(users[0]);
    }

    public async Task BlockUser(Guid id, DateTime date)
    {
        var users = await _userRepository.FilterList(new FilterUserParams() { Ids = new List<Guid>() { id } });
        if (users.Count == 0)
        {
            throw new Exception("User not found");
        }
        users[0].BlockedUntil = date;
        await _userRepository.Update(users[0]);
    }
}