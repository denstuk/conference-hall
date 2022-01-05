using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using ConferenceHall.API.Application.Hubs;
using ConferenceHall.API.Infrastructure;
using ConferenceHall.API.Infrastructure.Database;
using ConferenceHall.API.Infrastructure.Documentation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;

/* Application builder configuration */
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddSignalR();
builder.Services.AddDbContext<DatabaseContext>(x =>
{
    x.UseNpgsql(builder.Configuration.GetConnectionString("DbPostgres"));
});

DependencyInjection.Register(builder.Services);
SwaggerDocumentation.Register(builder.Services);

//builder.Services.AddCors();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["TOKEN_ISSUER"],
        ValidAudience = builder.Configuration["TOKEN_AUDIENCE"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["TOKEN_SECRET"]))
    };
});
builder.Services.AddAuthorization();
builder.Services.AddLogging();
builder.Services.AddHealthChecks();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddSingleton<IDictionary<string, ConnectionDto>>(opts => new Dictionary<string, ConnectionDto>());

/* Application configuration */
var app = builder.Build();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Static")),
    RequestPath = new PathString("/static")
});
app.UseRouting();
app.MapHub<ConferenceHub>("/chatHub", options =>
{
    options.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.WebSockets;
});
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.Run();
