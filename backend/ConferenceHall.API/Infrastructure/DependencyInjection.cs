using ConferenceHall.API.Application.Http.Providers;
using ConferenceHall.API.Domain.Auth;
using ConferenceHall.API.Domain.Auth.Interfaces;
using ConferenceHall.API.Domain.Conferences.Interfaces;
using ConferenceHall.API.Domain.Conferences.Services;
using ConferenceHall.API.Domain.Files.Interfaces;
using ConferenceHall.API.Domain.Files.Services;
using ConferenceHall.API.Domain.Users.Interfaces;
using ConferenceHall.API.Domain.Users.Services;
using ConferenceHall.API.Infrastructure.Database.Repositories;
using ConferenceHall.API.Infrastructure.Database.Repositories.Interfaces;

namespace ConferenceHall.API.Infrastructure
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
		}
	}
}
