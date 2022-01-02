using ConferenceHall.API.Domain.Entities;
using ConferenceHall.API.Infrastructure.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConferenceHall.API.Infrastructure.Database.Repositories
{
	public struct FilterListParams
	{
		public List<Guid>? Ids { get; set; }
		public string? Email { get; set; }
		public string? Login { get; set; }
		public int? Take { get; set; } = 25;
		public int? Skip { get; set; } = 0;
		public bool? JoinConferences { get; set; } = false;
	}
	
	public class UserRepository : BaseRepository<UserEntity>, IUserRepository
	{
		public UserRepository(DatabaseContext context) : base(context) {}
		public async Task<List<UserEntity>> FilterList(FilterListParams filterParams)
		{
			var qb = _dbSet.AsQueryable();
			if (filterParams.Ids is not null) qb = qb.Where((u) => filterParams.Ids.Contains(u.Id));
			if (filterParams.Email is not null) qb = qb.Where((u) => u.Email == filterParams.Email);
			if (filterParams.Login is not null) qb = qb.Where((u) => u.Login == filterParams.Login);
			if (filterParams.JoinConferences == true) qb = qb.Include((u) => u.Conferences);
			if (filterParams.Take is not null) qb = qb.Take((int)filterParams.Take);
			if (filterParams.Skip is not null) qb = qb.Skip((int)filterParams.Skip);
			return await qb.ToListAsync();
		}
	}
}
