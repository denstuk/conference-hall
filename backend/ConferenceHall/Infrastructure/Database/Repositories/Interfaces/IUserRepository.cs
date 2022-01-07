using ConferenceHall.Domain.Users.Dtos;
using ConferenceHall.Domain.Users.Entities;

namespace ConferenceHall.Infrastructure.Database.Repositories.Interfaces
{
	public interface IUserRepository : IBaseRepository<UserEntity>
	{
		Task<List<UserEntity>> FilterList(FilterUserParams filterParams);
	}
}
