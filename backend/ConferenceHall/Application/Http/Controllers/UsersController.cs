using AutoMapper;
using ConferenceHall.Domain.Users.Commands;
using ConferenceHall.Domain.Users.Dtos;
using ConferenceHall.Domain.Users.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceHall.Application.Http.Controllers
{
	public class UsersController : ApiController
	{
		private readonly IUserService _userService;
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		public UsersController(IUserService userService, IMapper mapper, IMediator mediator)
		{
			_userService = userService;
			_mapper = mapper;
			_mediator = mediator;
		}
		
		/// <summary>
		/// Search users
		/// </summary>
		[HttpPost("search")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetUsers([FromBody] FilterUserParams filterParams)
		{
			var users = await _userService.GetUsersFilter(filterParams);
			return Ok(_mapper.Map<IEnumerable<UserResponseDto>>(users));
		}

		/// <summary>
		/// Delete user by id
		/// </summary>
		[HttpDelete("{userId}")]
		public async Task<ActionResult> DeleteUserById([FromRoute] Guid userId)
		{
			await _mediator.Send(new DeleteUserCommand() { Id = userId });
			return Ok();
		}
		
		/// <summary>
		/// Block user by id until provided date
		/// </summary>
		[HttpPost("{userId}/block")]
		public async Task<ActionResult> BlockUserById([FromRoute] Guid userId, [FromBody] DateTime until)
		{
			await _mediator.Send(new BlockUserCommand() { Id = userId, BlockedUntil = until });
			return Ok();
		}
	}
}
