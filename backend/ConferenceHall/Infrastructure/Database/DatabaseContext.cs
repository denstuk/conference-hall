using ConferenceHall.Domain.Conferences.Entities;
using ConferenceHall.Domain.Messages.Entities;
using ConferenceHall.Domain.Shared;
using ConferenceHall.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConferenceHall.Infrastructure.Database
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

		public override int SaveChanges()
		{
			SetTimestamps();
			return base.SaveChanges();
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
		{
			SetTimestamps();
			return base.SaveChangesAsync(cancellationToken);
		}

		private void SetTimestamps()
		{
			var entries = ChangeTracker.Entries();
			var utcNow = DateTime.UtcNow;
			foreach (var entry in entries)
			{
				if (entry.Entity is BaseEntity trackable)
				{
					switch (entry.State)
					{
						case EntityState.Modified:
							trackable.UpdatedAt = utcNow;
							entry.Property("CreatedAt").IsModified = false;
							break;
						case EntityState.Added:
							trackable.CreatedAt = utcNow;
							trackable.UpdatedAt = utcNow;
							break;
					}
				}
			}
		}
	}
}
