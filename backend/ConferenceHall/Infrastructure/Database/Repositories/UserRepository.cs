using ConferenceHall.Domain.Users.Dtos;
using ConferenceHall.Domain.Users.Entities;
using ConferenceHall.Infrastructure.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConferenceHall.Infrastructure.Database.Repositories
{
	public class UserRepository : BaseRepository<UserEntity>, IUserRepository
	{
		public UserRepository(DatabaseContext context) : base(context) {}
		public async Task<List<UserEntity>> FilterList(FilterUserParams filterParams)
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
