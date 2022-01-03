using ConferenceHall.API.Infrastructure.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConferenceHall.API.Infrastructure.Database.Repositories
{
	public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
		protected readonly DatabaseContext Context;
		protected readonly DbSet<TEntity> _dbSet;

		protected BaseRepository(DatabaseContext context)
		{
			Context = context;
			_dbSet = context.Set<TEntity>();
		}

        public async Task Add(TEntity entity)
        {
            await Context.AddAsync(entity);
            await SaveChanges();
        }

        public async Task Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            var entities = await _dbSet.ToListAsync();
            return entities;
        }

        public async Task Insert(TEntity entity)
        {
            await Context.AddAsync(entity);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await Context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            await Context.SaveChangesAsync();
        }
    }
}
