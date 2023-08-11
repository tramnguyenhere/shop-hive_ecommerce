using System.Text;
using Backend.Business.src.Abstractions;
using Backend.Business.src.Implementations;
using Backend.Domain.src.Abstractions;
using Backend.Infrastructure.src.Database;
using Backend.Infrastructure.src.RepoImplementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add Automapper DI
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//Add DBContext
builder.Services.AddDbContext<DatabaseContext>();

// Add service DI
builder.Services
    .AddScoped<IUserRepository, UserRepo>()
    .AddScoped<IUserService, UserService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options=>{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme{
        Description = "Bearer token authentication",
        Name = "Authentication",
        In = ParameterLocation.Header
    });
    //Show the authorization required in ui
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

// Configure the route
builder.Services.Configure<RouteOptions>(options=>{
    options.LowercaseUrls = true;
});

// Configure the authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => 
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "ecommerce-backend",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my-secret-key")),
            ValidateIssuerSigningKey = true
        };
    }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
