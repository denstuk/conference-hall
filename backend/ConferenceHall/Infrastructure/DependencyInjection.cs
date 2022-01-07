using ConferenceHall.Application.Http.Providers;
using ConferenceHall.Domain.Auth;
using ConferenceHall.Domain.Auth.Interfaces;
using ConferenceHall.Domain.Conferences.Interfaces;
using ConferenceHall.Domain.Conferences.Services;
using ConferenceHall.Domain.Files.Interfaces;
using ConferenceHall.Domain.Files.Services;
using ConferenceHall.Domain.Messages.Interfaces;
using ConferenceHall.Domain.Messages.Services;
using ConferenceHall.Domain.Users.Interfaces;
using ConferenceHall.Domain.Users.Services;
using ConferenceHall.Infrastructure.Database.Repositories;
using ConferenceHall.Infrastructure.Database.Repositories.Interfaces;

namespace ConferenceHall.Infrastructure
{
	internal static class DependencyInjection
	{
		public static void Register(IServiceCollection services)
		{
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IConferenceRepository, ConferenceRepository>();
			services.AddScoped<IMessageRepository, MessageRepository>();
			
			services.AddScoped<IHashService, HashService>();
			services.AddScoped<IFileService, FileService>();
			services.AddScoped<IJwtService, JwtService>();
			services.AddScoped<IHttpProvider, HttpProvider>();
			
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IConferenceService, ConferenceService>();
			services.AddScoped<IMessageService, MessageService>();
		}
	}
}
