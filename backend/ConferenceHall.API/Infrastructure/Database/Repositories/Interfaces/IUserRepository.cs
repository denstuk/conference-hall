using ConferenceHall.API.Domain.Entities;

namespace ConferenceHall.API.Infrastructure.Database.Repositories.Interfaces
{
	public interface IUserRepository : IBaseRepository<UserEntity>
	{
		Task<List<UserEntity>> FilterList(FilterListParams filterParams);
	}
}
