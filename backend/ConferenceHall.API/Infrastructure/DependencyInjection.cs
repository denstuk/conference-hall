using ConferenceHall.API.Application.Http.Providers;
using ConferenceHall.API.Domain.Services;
using ConferenceHall.API.Domain.Services.Interfaces;
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
			services.AddScoped<IHashService, HashService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IFileService, FileService>();
			services.AddScoped<IJwtService, JwtService>();
			services.AddScoped<IHttpProvider, HttpProvider>();
		}
	}
}
