using Microsoft.EntityFrameworkCore;
using MinoBank.API.Helpers;
using MinoBank.Business.Services;
using MinoBank.Core.Interfaces.Auth;
using MinoBank.Core.Interfaces.Repositories;
using MinoBank.Core.Interfaces.Services;
using MinoBank.Infrastructure.Helpers;
using MinoBank.Infrastructure.Data;
using MinoBank.Infrastructure.Identity.Repositories;
using MinoBank.Infrastructure.Data.Repositories;
using MinoBank.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MinoBankDbContext>(options =>{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(MinoBankDbContext)));
});
builder.Services.AddDbContext<UserIdentityDbContext>(options =>{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(UserIdentityDbContext)));
});

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
    });

builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection(nameof(JwtConfiguration)));
var jwtConfig = builder.Configuration.GetSection(nameof(JwtConfiguration)).Get<JwtConfiguration>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>{
        options.TokenValidationParameters = new ()
        {
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.SecretKey))
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IBankAccountsRepository, BankAccountsRepository>();
builder.Services.AddScoped<IBankCardsRepository, BankCardsRepository>();
builder.Services.AddScoped<IBankTransactionsRepository, BankTransactionsRepository>();
builder.Services.AddScoped<IBankAccountsService, BankAccountsService>();
builder.Services.AddScoped<IBankCardsService, BankCardsService>();
builder.Services.AddScoped<IBankTransactionsService, BankTransactionsService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddAutoMapper(typeof(BankAccountProfile));
builder.Services.AddAutoMapper(typeof(BankCardProfile));
builder.Services.AddAutoMapper(typeof(BankTransactionProfile));
builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection(nameof(JwtConfiguration)));
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAll");
app.MapControllers();
app.Run();