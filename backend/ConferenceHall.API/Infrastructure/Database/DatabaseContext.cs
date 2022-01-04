using ConferenceHall.API.Domain.Conferences.Entities;
using ConferenceHall.API.Domain.Messages.Entities;
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
			
			modelBuilder.Entity<ConferenceEntity>()
				.HasOne(u => u.Creator)
				.WithMany(u => u.CreatedConferences)
				.HasForeignKey(k => k.CreatorId);

			modelBuilder.Entity<MessageEntity>()
				.HasOne(m => m.Creator)
				.WithMany(u => u.Messages)
				.HasForeignKey(m => m.CreatorId);

			modelBuilder.Entity<MessageEntity>()
				.HasOne(m => m.Conference)
				.WithMany(c => c.Messages)
				.HasForeignKey(m => m.ConferenceId);
		}
	}
}
