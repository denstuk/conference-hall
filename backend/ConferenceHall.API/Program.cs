using System.Text;
using ConferenceHall.API.Infrastructure;
using ConferenceHall.API.Infrastructure.Database;
using ConferenceHall.API.Infrastructure.Documentation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;

/* Application builder configuration */
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<DatabaseContext>(x =>
{
    x.UseNpgsql(builder.Configuration.GetConnectionString("DbPostgres"));
});

DependencyInjection.Register(builder.Services);
SwaggerDocumentation.Register(builder.Services);

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
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

/* Application configuration */
var app = builder.Build();  
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Static")),
    RequestPath = new PathString("/static")
});
app.Run();
