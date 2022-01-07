using ConferenceHall.Domain.Shared;
using ConferenceHall.Infrastructure.Database.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ConferenceHall.Infrastructure.Database
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			UserConfiguration.Configure(modelBuilder);
			ConferenceConfiguration.Configure(modelBuilder);
			MessageConfiguration.Configure(modelBuilder);
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
