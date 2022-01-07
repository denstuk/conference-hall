using ConferenceHall.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConferenceHall.Infrastructure.Database.Configuration;

public static class UserConfiguration
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>()
            .HasMany(p => p.Conferences)
            .WithMany(c => c.Users)
            .UsingEntity(j => j.ToTable("user_conference"));
    }
}