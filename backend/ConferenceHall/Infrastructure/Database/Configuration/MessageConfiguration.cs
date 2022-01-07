using ConferenceHall.Domain.Messages.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConferenceHall.Infrastructure.Database.Configuration;

public static class MessageConfiguration
{
    public static void Configure(ModelBuilder modelBuilder)
    {
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