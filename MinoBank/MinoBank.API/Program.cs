using Microsoft.EntityFrameworkCore;
using MinoBank.API.Helpers;
using MinoBank.Business.Services;
using MinoBank.Core.Interfaces.Auth;
using MinoBank.Core.Interfaces.Repositories;
using MinoBank.Core.Interfaces.Services;
using MinoBank.Infrastructure.Helpers;
using MinoBank.Infrastructure.Data;
using MinoBank.Infrastructure.Data.Repositories;
using MinoBank.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using MinoBank.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MinoBankDbContext>(options =>{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(MinoBankDbContext)));
});
builder.Services.AddDbContext<UserIdentityDbContext>(options =>{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(UserIdentityDbContext)));
});

builder.Services.AddIdentity<UserEntity, RoleEntity>()
    .AddEntityFrameworkStores<UserIdentityDbContext>()
    .AddDefaultTokenProviders();

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

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;})
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

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CustomerPolicy", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole("Customer");
        policy.RequireClaim("userId");
    });
    options.AddPolicy("AdminPolicy", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole("Admin");
    });
});

builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IBankAccountsRepository, BankAccountsRepository>();
builder.Services.AddScoped<IBankCardsRepository, BankCardsRepository>();
builder.Services.AddScoped<IBankTransactionsRepository, BankTransactionsRepository>();
builder.Services.AddScoped<IBankAccountsService, BankAccountsService>();
builder.Services.AddScoped<IBankCardsService, BankCardsService>();
builder.Services.AddScoped<IBankTransactionsService, BankTransactionsService>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddAutoMapper(typeof(BankAccountProfile));
builder.Services.AddAutoMapper(typeof(BankCardProfile));
builder.Services.AddAutoMapper(typeof(BankTransactionProfile));
builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection(nameof(JwtConfiguration)));

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{
    // Add Bearer token security definition
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and your token in the text input below.\nExample: \"Bearer abc123xyz\""
    });

    // Add global security requirement
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


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