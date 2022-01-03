using ConferenceHall.API.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConferenceHall.API.Infrastructure.Database
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserEntity>()
				.HasMany(p => p.Conferences)
				.WithMany(c => c.Users)
				.UsingEntity(j => j.ToTable("user_conference"));
		}
	}
}
