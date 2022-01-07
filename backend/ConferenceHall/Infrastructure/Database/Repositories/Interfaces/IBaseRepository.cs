namespace ConferenceHall.Infrastructure.Database.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        Task SaveChanges();
        Task Insert(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<IEnumerable<TEntity>> Get();
    }
}
