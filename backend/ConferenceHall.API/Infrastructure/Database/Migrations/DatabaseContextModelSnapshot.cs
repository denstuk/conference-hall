﻿// <auto-generated />
using System;
using ConferenceHall.API.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConferenceHall.API.Infrastructure.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ConferenceEntityUserEntity", b =>
                {
                    b.Property<Guid>("ConferencesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uuid");

                    b.HasKey("ConferencesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("user_conference", (string)null);
                });

            modelBuilder.Entity("ConferenceHall.API.Domain.Conferences.Entities.ConferenceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uuid")
                        .HasColumnName("creator_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("title");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("conferences");
                });

            modelBuilder.Entity("ConferenceHall.API.Domain.Messages.Entities.MessageEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("ConferenceId")
                        .HasColumnType("uuid")
                        .HasColumnName("conference_id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uuid")
                        .HasColumnName("creator_id");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceId");

                    b.HasIndex("CreatorId");

                    b.ToTable("message");
                });

            modelBuilder.Entity("ConferenceHall.API.Domain.Users.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime?>("BlockedUntil")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("blocked_until");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("salt");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("ConferenceEntityUserEntity", b =>
                {
                    b.HasOne("ConferenceHall.API.Domain.Conferences.Entities.ConferenceEntity", null)
                        .WithMany()
                        .HasForeignKey("ConferencesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConferenceHall.API.Domain.Users.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConferenceHall.API.Domain.Conferences.Entities.ConferenceEntity", b =>
                {
                    b.HasOne("ConferenceHall.API.Domain.Users.Entities.UserEntity", "Creator")
                        .WithMany("CreatedConferences")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("ConferenceHall.API.Domain.Messages.Entities.MessageEntity", b =>
                {
                    b.HasOne("ConferenceHall.API.Domain.Conferences.Entities.ConferenceEntity", "Conference")
                        .WithMany("Messages")
                        .HasForeignKey("ConferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConferenceHall.API.Domain.Users.Entities.UserEntity", "Creator")
                        .WithMany("Messages")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conference");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("ConferenceHall.API.Domain.Conferences.Entities.ConferenceEntity", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("ConferenceHall.API.Domain.Users.Entities.UserEntity", b =>
                {
                    b.Navigation("CreatedConferences");

                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
