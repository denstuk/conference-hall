using ConferenceHall.Domain.Conferences.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConferenceHall.Infrastructure.Database.Configuration;

public static class ConferenceConfiguration
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConferenceEntity>()
            .HasOne(u => u.Creator)
            .WithMany(u => u.CreatedConferences)
            .HasForeignKey(k => k.CreatorId);
    }
}