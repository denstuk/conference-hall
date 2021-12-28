using AutoMapper;
using ConferenceHall.API.Domain.Dtos;
using ConferenceHall.API.Domain.Entities;
using ConferenceHall.API.Domain.Services.Interfaces;
using ConferenceHall.API.Infrastructure.Database.Repositories.Interfaces;

namespace ConferenceHall.API.Domain.Services;

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

    public Task<IEnumerable<UserEntity>> GetUsersFilter()
    {
        return _userRepository.Get();
    }

    public async Task<UserEntity> CreateUser(SignUpDto dto)
    {
        var user = _mapper.Map<UserEntity>(dto);
        user.Password = _hashService.Create(dto.Password);
        await _userRepository.Insert(user);
        return user;
    }
}