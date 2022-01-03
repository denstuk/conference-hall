using AutoMapper;
using ConferenceHall.API.Domain.Auth.Dtos;
using ConferenceHall.API.Domain.Users.Dtos;
using ConferenceHall.API.Domain.Users.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceHall.API.Application.Http.Controllers
{
	public class UsersController : ApiController
	{
		private readonly IUserService _userService;
		private readonly IMapper _mapper;

		public UsersController(IUserService userService, IMapper mapper)
		{
			_userService = userService;
			_mapper = mapper;
		}

		[HttpGet("")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		public async Task<ActionResult<IEnumerable<SecureUserDto>>> GetUsers()
		{
			var users = await _userService.GetUsersFilter();
			return Ok(_mapper.Map<IEnumerable<SecureUserDto>>(users));
		}

		[HttpPost("")]
		public async Task<ActionResult<SecureUserDto>> CreateUser([FromBody] SignUpDto dto)
		{
			var user = await _userService.CreateUser(dto);
			return Ok(user);
		}
	}
}
