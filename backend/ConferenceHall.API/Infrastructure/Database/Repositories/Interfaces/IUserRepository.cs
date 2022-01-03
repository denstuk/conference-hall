using ConferenceHall.API.Domain.Users.Entities;

namespace ConferenceHall.API.Infrastructure.Database.Repositories.Interfaces
{
	public interface IUserRepository : IBaseRepository<UserEntity>
	{
		Task<List<UserEntity>> FilterList(FilterListParams filterParams);
	}
}
