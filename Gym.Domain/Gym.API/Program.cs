
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Gym.API.Core;
using Gym.API;
using Gym.Application;
using Gym.Implementation;
using Gym.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var settings = new AppSettings();

builder.Configuration.Bind(settings);
builder.Services.AddSingleton(settings.Jwt);
builder.Services.AddAutoMapper(typeof(UseCaseInfo).Assembly);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<GymContext>(x => new GymContext(settings.ConnectionString));
builder.Services.AddScoped<IDbConnection>(x => new SqlConnection(settings.ConnectionString));
builder.Services.AddTransient<JwtTokenCreator>();


builder.Services.AddHttpContextAccessor();
builder.Services.AddUseCases();
builder.Services.AddTransient<IExceptionLogger, DbExceptionLogger>();
builder.Services.AddTransient<ITokenStorage, InMemoryTokenStorage>();

builder.Services.AddTransient<IApplicationActorProvider>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();

    var request = accessor.HttpContext.Request;

    var authHeader = request.Headers.Authorization.ToString();

    var context = x.GetService<GymContext>();

    return new JwtApplicationActorProvider(authHeader);
});
builder.Services.AddTransient<IApplicationActor>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();
    if (accessor.HttpContext == null)
    {
        return new UnauthorizedActor();
    }

    return x.GetService<IApplicationActorProvider>().GetActor();
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = settings.Jwt.Issuer,
        ValidateIssuer = true,
        ValidAudience = "Any",
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Jwt.SecretKey)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
    cfg.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            //Token dohvatamo iz Authorization header-a

            Guid tokenId = context.HttpContext.Request.GetTokenId().Value;

            var storage = builder.Services.BuildServiceProvider().GetService<ITokenStorage>();

            if (!storage.Exists(tokenId))
            {
                context.Fail("Invalid token");
            }


            return Task.CompletedTask;

        }
    };
});






//builder.Services.AddScoped<IApplicationActorProvider, DefaultActorProvider>();

var app = builder.Build();
app.UseCors(x =>
{
    x.AllowAnyOrigin();
    x.AllowAnyMethod();
    x.AllowAnyHeader();
});

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.Run();
